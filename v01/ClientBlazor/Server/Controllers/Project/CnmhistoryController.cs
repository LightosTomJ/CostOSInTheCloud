using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Project;

namespace ClientBlazor.Server.Controllers.Project
{
    [Route("api/[controller]")]
    [ApiController]
    public class CnmhistoryController : ControllerBase
    {
        private readonly projectContext _context;

        public CnmhistoryController(projectContext context)
        {
            _context = context;
        }

        // GET: api/Cnmhistory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cnmhistory>>> GetCnmhistory()
        {
            return await _context.Cnmhistory.ToListAsync();
        }

        // GET: api/Cnmhistory/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cnmhistory>> GetCnmhistory(long id)
        {
            var cnmhistory = await _context.Cnmhistory.FindAsync(id);

            if (cnmhistory == null)
            {
                return NotFound();
            }

            return cnmhistory;
        }

        // PUT: api/Cnmhistory/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnmhistory(long id, Cnmhistory cnmhistory)
        {
            if (id != cnmhistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(cnmhistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnmhistoryExists(id))
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

        // POST: api/Cnmhistory
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Cnmhistory>> PostCnmhistory(Cnmhistory cnmhistory)
        {
            _context.Cnmhistory.Add(cnmhistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCnmhistory", new { id = cnmhistory.Id }, cnmhistory);
        }

        // DELETE: api/Cnmhistory/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cnmhistory>> DeleteCnmhistory(long id)
        {
            var cnmhistory = await _context.Cnmhistory.FindAsync(id);
            if (cnmhistory == null)
            {
                return NotFound();
            }

            _context.Cnmhistory.Remove(cnmhistory);
            await _context.SaveChangesAsync();

            return cnmhistory;
        }

        private bool CnmhistoryExists(long id)
        {
            return _context.Cnmhistory.Any(e => e.Id == id);
        }
    }
}
