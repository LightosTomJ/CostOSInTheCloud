using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;

namespace ClientBlazor.Server.Controllers.Local
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlcObjectsStatusController : ControllerBase
    {
        private readonly localContext _context;

        public AlcObjectsStatusController(localContext context)
        {
            _context = context;
        }

        // GET: api/AlcObjectsStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlcObjectsStatus>>> GetAlcObjectsStatus()
        {
            return await _context.AlcObjectsStatus.ToListAsync();
        }

        // GET: api/AlcObjectsStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlcObjectsStatus>> GetAlcObjectsStatus(string id)
        {
            var alcObjectsStatus = await _context.AlcObjectsStatus.FindAsync(id);

            if (alcObjectsStatus == null)
            {
                return NotFound();
            }

            return alcObjectsStatus;
        }

        // PUT: api/AlcObjectsStatus/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlcObjectsStatus(string id, AlcObjectsStatus alcObjectsStatus)
        {
            if (id != alcObjectsStatus.ObjId)
            {
                return BadRequest();
            }

            _context.Entry(alcObjectsStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlcObjectsStatusExists(id))
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

        // POST: api/AlcObjectsStatus
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<AlcObjectsStatus>> PostAlcObjectsStatus(AlcObjectsStatus alcObjectsStatus)
        {
            _context.AlcObjectsStatus.Add(alcObjectsStatus);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlcObjectsStatusExists(alcObjectsStatus.ObjId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAlcObjectsStatus", new { id = alcObjectsStatus.ObjId }, alcObjectsStatus);
        }

        // DELETE: api/AlcObjectsStatus/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AlcObjectsStatus>> DeleteAlcObjectsStatus(string id)
        {
            var alcObjectsStatus = await _context.AlcObjectsStatus.FindAsync(id);
            if (alcObjectsStatus == null)
            {
                return NotFound();
            }

            _context.AlcObjectsStatus.Remove(alcObjectsStatus);
            await _context.SaveChangesAsync();

            return alcObjectsStatus;
        }

        private bool AlcObjectsStatusExists(string id)
        {
            return _context.AlcObjectsStatus.Any(e => e.ObjId == id);
        }
    }
}
