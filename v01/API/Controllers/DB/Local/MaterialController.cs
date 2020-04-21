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
        private readonly localContext _context;

        public MaterialController(localContext context)
        {
            _context = context;
        }

        // GET: api/Material
        [HttpGet]
        public async Task<IList<Material>> GetMaterial()
        {
            return await _context.Material.ToListAsync();
        }

        // GET: api/Material/5
        [HttpGet("{id}")]
        public async Task<Material> GetMaterial(long id)
        {
            var material = await _context.Material.FindAsync(id);

            if (material == null)
            {
                return null;
            }

            return material;
        }

        // PUT: api/Material/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterial(long id, Material material)
        {
            if (id != material.Materialid)
            {
                return BadRequest();
            }

            _context.Entry(material).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Material
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<Material> PostMaterial(Material material)
        {
            _context.Material.Add(material);
            await _context.SaveChangesAsync();

            return material;
        }

        // DELETE: api/Material/5
        [HttpDelete("{id}")]
        public async Task<Material> DeleteMaterial(long id)
        {
            var material = await _context.Material.FindAsync(id);
            if (material == null)
            {
                return null;
            }

            _context.Material.Remove(material);
            await _context.SaveChangesAsync();

            return material;
        }

        private bool MaterialExists(long id)
        {
            return _context.Material.Any(e => e.Materialid == id);
        }
    }
}
