using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace API.Controllers.DB.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldcustomController : ControllerBase
    {
        private readonly LocalContext _context;

        public FieldcustomController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Fieldcustom
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FieldCustom>>> GetFieldcustom()
        {
            return await _context.FieldCustom.ToListAsync();
        }

        // GET: api/Fieldcustom/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FieldCustom>> GetFieldcustom(long id)
        {
            var fieldcustom = await _context.FieldCustom.FindAsync(id);

            if (fieldcustom == null)
            {
                return NotFound();
            }

            return fieldcustom;
        }

        // PUT: api/Fieldcustom/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFieldcustom(long id, FieldCustom fieldcustom)
        {
            if (id != fieldcustom.Id)
            {
                return BadRequest();
            }

            _context.Entry(fieldcustom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FieldcustomExists(id))
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

        // POST: api/Fieldcustom
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<FieldCustom>> PostFieldcustom(FieldCustom fieldcustom)
        {
            _context.FieldCustom.Add(fieldcustom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFieldcustom", new { id = fieldcustom.Id }, fieldcustom);
        }

        // DELETE: api/Fieldcustom/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FieldCustom>> DeleteFieldcustom(long id)
        {
            var fieldcustom = await _context.FieldCustom.FindAsync(id);
            if (fieldcustom == null)
            {
                return NotFound();
            }

            _context.FieldCustom.Remove(fieldcustom);
            await _context.SaveChangesAsync();

            return fieldcustom;
        }

        private bool FieldcustomExists(long id)
        {
            return _context.FieldCustom.Any(e => e.Id == id);
        }
    }
}
