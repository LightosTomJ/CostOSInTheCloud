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
    public class BcMaterialController : ControllerBase
    {
        private readonly LocalContext _context;

        public BcMaterialController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/BcMaterial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcMaterial>>> GetBcMaterial()
        {
            return await _context.BcMaterial.ToListAsync();
        }

        // GET: api/BcMaterial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcMaterial>> GetBcMaterial(long id)
        {
            var bcMaterial = await _context.BcMaterial.FindAsync(id);

            if (bcMaterial == null)
            {
                return NotFound();
            }

            return bcMaterial;
        }

        // PUT: api/BcMaterial/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcMaterial(long id, BcMaterial bcMaterial)
        {
            if (id != bcMaterial.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcMaterialExists(id))
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

        // POST: api/BcMaterial
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcMaterial>> PostBcMaterial(BcMaterial bcMaterial)
        {
            _context.BcMaterial.Add(bcMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcMaterial", new { id = bcMaterial.Id }, bcMaterial);
        }

        // DELETE: api/BcMaterial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcMaterial>> DeleteBcMaterial(long id)
        {
            var bcMaterial = await _context.BcMaterial.FindAsync(id);
            if (bcMaterial == null)
            {
                return NotFound();
            }

            _context.BcMaterial.Remove(bcMaterial);
            await _context.SaveChangesAsync();

            return bcMaterial;
        }

        private bool BcMaterialExists(long id)
        {
            return _context.BcMaterial.Any(e => e.Id == id);
        }
    }
}
