using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.v1;

public class StudentController : BaseApiController
{
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(StudentStatic.GetAllStudent());
    }

    [HttpGet("{rollNo}")]
    public IActionResult GetA(string rollNo)
    {
        return Ok(StudentStatic.GetAStudent(rollNo));
    }

    [HttpPost]
    public IActionResult Insert([FromForm] Student student)
    {
        return Ok(StudentStatic.InsertStudent(student));
    }

    [HttpPut("{rollNo}")]
    public IActionResult Update(string rollNo, Student student)
    {
        return Ok(StudentStatic.UpdateStudent(rollNo, student));
    }

    [HttpDelete("{rollNo}")]
    public IActionResult Delete(string rollNo)
    {
        return Ok(StudentStatic.DeleteStudent(rollNo));
    }
    
    public static class StudentStatic
    {
        private static List<Student> allStudents { get; set; } = new List<Student>();

        public static Student InsertStudent(Student student)
        {
            allStudents.Add(student);
            return student;
        }

        public static List<Student> GetAllStudent()
        {
            return allStudents;
        }

        public static Student GetAStudent(string rollNo)
        {
            var aStudent =  allStudents.FirstOrDefault(x => x.RollNo.ToLower() == rollNo.ToLower());
            
            if (aStudent != null)
            {
                return aStudent;
            }
            return null;
        }

        public static Student UpdateStudent(string rollNo, Student student)
        {
            foreach (var item in allStudents)
            {
                if (item.RollNo == rollNo)
                {
                    item.Name = student.Name;
                    item.DepartmentCode = student.DepartmentCode;
                }
            }
            return student;
        }

        public static Student DeleteStudent(string rollNo)
        {
            var aStudent = allStudents.FirstOrDefault(x => x.RollNo.ToLower() == rollNo.ToLower());
            if (aStudent == null)
            {
                return null;
            }

            allStudents.Remove(aStudent);
            return aStudent;
        }
    }
}