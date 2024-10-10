using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using System;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/lessons")]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;

        public LessonController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var lessons = await _lessonService.GetAllAsync();
            return Ok(lessons);
        }

        [HttpGet("{teacherId:guid}/{clientId:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid teacherId, Guid clientId)
        {
            var lesson = await _lessonService.GetByIdAsync(teacherId, clientId);
            if (lesson == null)
            {
                return NotFound("Урок не найден.");
            }

            return Ok(lesson);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LessonDtoForCreate lessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLesson = await _lessonService.CreateAsync(lessonDto);
            return Ok(createdLesson);
        }

        [HttpPut("{teacherId:guid}/{clientId:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid teacherId, Guid clientId, [FromBody] LessonDtoForUpdate lessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _lessonService.UpdateAsync(teacherId, clientId, lessonDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Урок не найден.");
            }
        }

        [HttpDelete("{teacherId:guid}/{clientId:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid teacherId, Guid clientId)
        {
            try
            {
                await _lessonService.DeleteAsync(teacherId, clientId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Урок не найден.");
            }
        }

        [HttpGet("{teacherId:guid}/lessons")]
        public async Task<IActionResult> GetLessonsByDateAsync(Guid teacherId, [FromQuery] DateTime date)
        {
            var lessons = await _lessonService.GetLessonsByDateAsync(teacherId, date);
            if (lessons == null || lessons.Count == 0)
            {
                return NotFound("Уроки на указанную дату не найдены.");
            }

            return Ok(lessons);
        }
        [HttpPost("auto")]
        public async Task<IActionResult> CreateAuto([FromBody] LessonDtoForAutoCreate lessonDto)
        {
            var lesson = await _lessonService.CreateAuto(lessonDto);
            return Ok(lesson);
        }

    }
}
