using Contracts;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/teachers")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var teachers = await _teacherService.GetAllAsync();
            return Ok(teachers);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var teacher = await _teacherService.GetByIdAsync(id);

            if(teacher == null)
            {
                return NotFound("Преподаватель не найден.");
            }

            return Ok(teacher);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TeacherDtoForCreate teacherDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTeacher = await _teacherService.CreateAsync(teacherDto); 
            return Ok(newTeacher);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TeacherDtoForUpdate teacherDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _teacherService.UpdateAsync(id, teacherDto);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Клиент не найден.");
            }

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            try
            {
                await _teacherService.DeleteAsync(id);
                Ok();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("не найден.");
            }

            return NoContent();
        }
    }
}
