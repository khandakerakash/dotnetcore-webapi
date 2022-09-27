using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok("Get all departments");
    }

    [HttpGet("{code}")]
    public IActionResult GetA(string code)
    {
        return Ok("Get this " + code + " department");
    }

    [HttpPost]
    public IActionResult Insert()
    {
        return Ok("Insert a department");
    }
    
    [HttpPut("{code}")]
    public IActionResult Update(string code)
    {
        return Ok("Update this " + code + " department");
    }
    
    [HttpDelete("{code}")]
    public IActionResult Delete(string code)
    {
        return Ok("Delete this " + code + " department");
    }
}