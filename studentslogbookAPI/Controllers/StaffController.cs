using Microsoft.AspNetCore.Mvc;
using studentslogbookAPI.Data;
using studentslogbookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace studentslogbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {

        private DataContext _dataContext;

        public StaffController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<Student> students;
            
                students = _dataContext.students.Where(x => x.Role.Equals("Professor") || x.Role.Equals("Admin"));
            
            

            return Ok(students);
        }

    // PUT: api/Students/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutStudent(int id, Student student)
    {
      if (id != student.Id_Student)
      {
        return BadRequest();
      }

      _dataContext.Entry(student).State = EntityState.Modified;

      try
      {
        await _dataContext.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!StudentExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

        // POST: api/Student
  
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            _dataContext.students.Add(student);
            _dataContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }


// POST: api/Student
/*[HttpPost]
public async Task<ActionResult<Student>> PostStudent(Student student)
{
    _dataContext.students.Add(student);
    await _dataContext.SaveChangesAsync();

    return CreatedAtAction(nameof(Get), new { id = student.Id_Student }, student);
}*/


    [HttpPost("login")]
    
    public async Task<Student> Login(Login personForLogin)
    {
      var person =  _dataContext.students.FirstOrDefault(x => x.Student_Email == personForLogin.student_Email);
      var password = _dataContext.students.FirstOrDefault(x => x.Password == personForLogin.password);

      await _dataContext.students.ToListAsync();


      if (person == null)
      {
        return null;
      }
      else if (password == null) {
        return null;
      }
      else
      {
        return person;
      }
    }

    private bool StudentExists(int id)
    {
      return _dataContext.students.Any(e => e.Id_Student == id);
    }


  }
}
