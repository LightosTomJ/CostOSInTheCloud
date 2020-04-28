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
    public class BcGroupController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcGroupController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcGroup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcGroup>>> GetBcGroup()
        {
            return await _context.BcGroup.ToListAsync();
        }

        // GET: api/BcGroup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcGroup>> GetBcGroup(long id)
        {
            var bcGroup = await _context.BcGroup.FindAsync(id);

            if (bcGroup == null)
            {
                return NotFound();
            }

            return bcGroup;
        }

        // PUT: api/BcGroup/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcGroup(long id, BcGroup bcGroup)
        {
            if (id != bcGroup.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcGroupExists(id))
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

        // POST: api/BcGroup
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcGroup>> PostBcGroup(BcGroup bcGroup)
        {
            _context.BcGroup.Add(bcGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcGroup", new { id = bcGroup.Id }, bcGroup);
        }

        // DELETE: api/BcGroup/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcGroup>> DeleteBcGroup(long id)
        {
            var bcGroup = await _context.BcGroup.FindAsync(id);
            if (bcGroup == null)
            {
                return NotFound();
            }

            _context.BcGroup.Remove(bcGroup);
            await _context.SaveChangesAsync();

            return bcGroup;
        }

        private bool BcGroupExists(long id)
        {
            return _context.BcGroup.Any(e => e.Id == id);
        }
    }
}
