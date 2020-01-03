using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using studentslogbookAPI.Data;
using studentslogbookAPI.Models;

namespace studentslogbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicalignmentsController : ControllerBase
    {
        private readonly DataContext _context;

        public DynamicalignmentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Dynamicalignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dynamicalignment>>> Getdynamic()
        {
            return await _context.dynamic.ToListAsync();
        }

        // GET: api/Dynamicalignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dynamicalignment>> GetDynamicalignment(int id)
        {
            var dynamicalignment = await _context.dynamic.FindAsync(id);

            if (dynamicalignment == null)
            {
                return NotFound();
            }

            return dynamicalignment;
        }

        // PUT: api/Dynamicalignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDynamicalignment(int id, Dynamicalignment dynamicalignment)
        {
            if (id != dynamicalignment.Id_Dynamic)
            {
                return BadRequest();
            }

            _context.Entry(dynamicalignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DynamicalignmentExists(id))
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

        // POST: api/Dynamicalignments
        [HttpPost]
        public async Task<ActionResult<Dynamicalignment>> PostDynamicalignment(Dynamicalignment dynamicalignment)
        {
            _context.dynamic.Add(dynamicalignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDynamicalignment", new { id = dynamicalignment.Id_Dynamic }, dynamicalignment);
        }

        // DELETE: api/Dynamicalignments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Dynamicalignment>> DeleteDynamicalignment(int id)
        {
            var dynamicalignment = await _context.dynamic.FindAsync(id);
            if (dynamicalignment == null)
            {
                return NotFound();
            }

            _context.dynamic.Remove(dynamicalignment);
            await _context.SaveChangesAsync();

            return dynamicalignment;
        }

        private bool DynamicalignmentExists(int id)
        {
            return _context.dynamic.Any(e => e.Id_Dynamic == id);
        }
    }
}
