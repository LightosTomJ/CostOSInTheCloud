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
    public class MaterialController : ControllerBase
    {
        private readonly LocalContext _context;

        public MaterialController(LocalContext context)
        {
            _context = context;
        }

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<IList<Material>>> GetMaterials()
        //public ActionResult<IList<Material>> GetMaterials()
        {
            ActionResult<IList<Material>> mats = new List<Material>();
            try
            {
                mats = await _context.Material.ToListAsync();
            }
            catch (Exception ae)
            { }
            return mats;
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterials(string id)
        {
            var roles = await _context.Material.FindAsync(id);

            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterials(long id, Material materials)
        {
            if (id != materials.Materialid)
            {
                return BadRequest();
            }

            _context.Entry(materials).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialsExists(id))
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

        // POST: api/Materials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Material>> PostMaterials(Material materials)
        {
            _context.Material.Add(materials);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaterialsExists(materials.Materialid))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaterials", new { id = materials.Materialid }, materials);
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Material>> DeleteMaterials(string id)
        {
            var roles = await _context.Material.FindAsync(id);
            if (roles == null)
            {
                return NotFound();
            }

            _context.Material.Remove(roles);
            await _context.SaveChangesAsync();

            return roles;
        }

        private bool MaterialsExists(long id)
        {
            return _context.Material.Any(e => e.Materialid == id);
        }
    }
}
