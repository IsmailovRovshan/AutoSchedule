using Contracts;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

[ApiController]
[Route("api/managers")]
public class ManagerController : ControllerBase
{
    private readonly IManagerService _managerService;

    public ManagerController(IManagerService managerService)
    {
        _managerService = managerService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var managers = await _managerService.GetAllAsync();
        return Ok(managers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        try
        {
            var manager = await _managerService.GetByIdAsync(id);
            return Ok(manager);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] ManagerDtoForCreate managerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var manager = await _managerService.CreateAsync(managerDto);
        return Ok(manager);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] ManagerDtoForUpdate managerDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        try
        {
            await _managerService.UpdateAsync(id, managerDto);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _managerService.DeleteAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}

