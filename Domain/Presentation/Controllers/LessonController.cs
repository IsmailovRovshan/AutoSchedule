using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

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

        // Получить все уроки
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var lessons = await _lessonService.GetAllAsync();
            return Ok(lessons);
        }

        // Получить урок по ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            try
            {
                var lesson = await _lessonService.GetByIdAsync(id);
                return Ok(lesson);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Урок не найден.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LessonDtoForCreate lessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLesson = await _lessonService.CreateAsync(lessonDto);
            return CreatedAtAction(nameof(GetByIdAsync),
                new { teacherId = createdLesson.TeacherId, 
                    clientId = createdLesson.ClientId }, createdLesson);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] LessonDtoForUpdate lessonDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _lessonService.UpdateAsync(id, lessonDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Урок не найден.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _lessonService.DeleteAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Урок не найден.");
            }
        }
    }
}
