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
    public class AlcUserSettingsController : ControllerBase
    {
        private readonly LocalContext _context;

        public AlcUserSettingsController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/AlcUserSettings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlcUserSettings>>> GetAlcUserSettings()
        {
            return await _context.AlcUserSettings.ToListAsync();
        }

        // GET: api/AlcUserSettings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlcUserSettings>> GetAlcUserSettings(Guid id)
        {
            var alcUserSettings = await _context.AlcUserSettings.FindAsync(id);

            if (alcUserSettings == null)
            {
                return NotFound();
            }

            return alcUserSettings;
        }

        // PUT: api/AlcUserSettings/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcUserSettings(Guid id, AlcUserSettings alcUserSettings)
        {
            if (id != alcUserSettings.UserId)
            {
                return BadRequest();
            }

            _context.Entry(alcUserSettings).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcUserSettingsExists(id))
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

        // POST: api/AlcUserSettings
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AlcUserSettings>> PostAlcUserSettings(AlcUserSettings alcUserSettings)
        {
            _context.AlcUserSettings.Add(alcUserSettings);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlcUserSettingsExists(alcUserSettings.UserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlcUserSettings", new { id = alcUserSettings.UserId }, alcUserSettings);
        }

        // DELETE: api/AlcUserSettings/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlcUserSettings>> DeleteAlcUserSettings(Guid id)
        {
            var alcUserSettings = await _context.AlcUserSettings.FindAsync(id);
            if (alcUserSettings == null)
            {
                return NotFound();
            }

            _context.AlcUserSettings.Remove(alcUserSettings);
            await _context.SaveChangesAsync();

            return alcUserSettings;
        }

        private bool AlcUserSettingsExists(Guid id)
        {
            return _context.AlcUserSettings.Any(e => e.UserId == id);
        }
    }
}
