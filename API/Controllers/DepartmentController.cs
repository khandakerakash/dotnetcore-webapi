using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class DepartmentController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(DepartmentStatic.GetAllDepartments());
    }

    [HttpGet("{code}")]
    public IActionResult GetA(string code)
    {
        return Ok(DepartmentStatic.GetADepartment(code));
    }

    [HttpPost]
    public IActionResult Insert(Department department)
    {
        return Ok(DepartmentStatic.InsertDepartment(department));
    }
    
    [HttpPut("{code}")]
    public IActionResult Update(string code, Department department)
    {
        return Ok(DepartmentStatic.UpdateADepartment(code, department));
    }
    
    [HttpDelete("{code}")]
    public IActionResult Delete(string code)
    {
        return Ok(DepartmentStatic.DeleteADepartment(code));
    }
    
    // Demo Class
    public static class DepartmentStatic
    {
        private static List<Department> allDepartments { get; set; } = new List<Department>();

        public static Department InsertDepartment(Department department)
        {
            allDepartments.Add(department);
            return department;
        }

        public static List<Department> GetAllDepartments()
        {
            return allDepartments;
        }

        public static Department GetADepartment(string code)
        {
            var aDepartment = allDepartments.Find(x => x.Code.ToLower() == code.ToLower());
            return aDepartment;
        }

        public static Department UpdateADepartment(string code, Department department)
        {
            foreach (var aDepartment in allDepartments)
            {
                if (code == aDepartment.Code)
                {
                    aDepartment.Name = department.Name;
                }
            }
            return department;
        }

        public static Department DeleteADepartment(string code)
        {
            var aDepartment = allDepartments.Find(x => x.Code.ToLower() == code.ToLower());
            
            if (aDepartment == null)
            {
                return null;
            }

            allDepartments.Remove(aDepartment);

            return aDepartment;
        }
    }
}
