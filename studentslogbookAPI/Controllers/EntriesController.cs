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
    public class EntriesController : ControllerBase
    {
        private readonly DataContext _context;

        public EntriesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Entries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> Getentry()
        {
            return await _context.entry.ToListAsync();
        }

        // GET: api/Entries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(int id)
        {
            var entry = await _context.entry.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry;
        }

        // PUT: api/Entries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry(int id, Entry entry)
        {
            if (id != entry.Id_Entry)
            {
                return BadRequest();
            }

            _context.Entry(entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
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

        // POST: api/Entries
        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(Entry entry)
        {
            _context.entry.Add(entry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntry", new { id = entry.Id_Entry }, entry);
        }

        // DELETE: api/Entries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entry>> DeleteEntry(int id)
        {
            var entry = await _context.entry.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            _context.entry.Remove(entry);
            await _context.SaveChangesAsync();

            return entry;
        }



    [HttpPost("ent")]

    public async Task<IActionResult> GetEntries(GetEntry getentry)
    {
      var get = _context.entry.Where(x => x.Student_Id_Student == getentry.Student_Id_Student);
      

      if (get == null)
      {
        return null;
      }
      else
      {
        await _context.entry.ToListAsync();
        return Ok(get.OrderByDescending(x => x.Id_Entry));
      }
    }

    private bool EntryExists(int id)
    {
      return _context.entry.Any(e => e.Id_Entry == id);
    }
    }

  

    
}
