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
    public class AlcSettingCodesController : ControllerBase
    {
        private readonly LocalContext _context;

        public AlcSettingCodesController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/AlcSettingCodes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlcSettingCodes>>> GetAlcSettingCodes()
        {
            return await _context.AlcSettingCodes.ToListAsync();
        }

        // GET: api/AlcSettingCodes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlcSettingCodes>> GetAlcSettingCodes(Guid id)
        {
            var alcSettingCodes = await _context.AlcSettingCodes.FindAsync(id);

            if (alcSettingCodes == null)
            {
                return NotFound();
            }

            return alcSettingCodes;
        }

        // PUT: api/AlcSettingCodes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcSettingCodes(Guid id, AlcSettingCodes alcSettingCodes)
        {
            if (id != alcSettingCodes.Id)
            {
                return BadRequest();
            }

            _context.Entry(alcSettingCodes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcSettingCodesExists(id))
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

        // POST: api/AlcSettingCodes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlcSettingCodes>> PostAlcSettingCodes(AlcSettingCodes alcSettingCodes)
        {
            _context.AlcSettingCodes.Add(alcSettingCodes);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlcSettingCodesExists(alcSettingCodes.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlcSettingCodes", new { id = alcSettingCodes.Id }, alcSettingCodes);
        }

        // DELETE: api/AlcSettingCodes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlcSettingCodes>> DeleteAlcSettingCodes(Guid id)
        {
            var alcSettingCodes = await _context.AlcSettingCodes.FindAsync(id);
            if (alcSettingCodes == null)
            {
                return NotFound();
            }

            _context.AlcSettingCodes.Remove(alcSettingCodes);
            await _context.SaveChangesAsync();

            return alcSettingCodes;
        }

        private bool AlcSettingCodesExists(Guid id)
        {
            return _context.AlcSettingCodes.Any(e => e.Id == id);
        }
    }
}
