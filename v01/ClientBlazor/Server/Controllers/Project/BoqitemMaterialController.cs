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
    public class BoqitemMaterialController : ControllerBase
    {
        private readonly projectContext _context;

        public BoqitemMaterialController(projectContext context)
        {
            _context = context;
        }

        // GET: api/BoqitemMaterial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoqitemMaterial>>> GetBoqitemMaterial()
        {
            return await _context.BoqitemMaterial.ToListAsync();
        }

        // GET: api/BoqitemMaterial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoqitemMaterial>> GetBoqitemMaterial(long id)
        {
            var boqitemMaterial = await _context.BoqitemMaterial.FindAsync(id);

            if (boqitemMaterial == null)
            {
                return NotFound();
            }

            return boqitemMaterial;
        }

        // PUT: api/BoqitemMaterial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitemMaterial(long id, BoqitemMaterial boqitemMaterial)
        {
            if (id != boqitemMaterial.Boqitemmaterialid)
            {
                return BadRequest();
            }

            _context.Entry(boqitemMaterial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemMaterialExists(id))
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

        // POST: api/BoqitemMaterial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoqitemMaterial>> PostBoqitemMaterial(BoqitemMaterial boqitemMaterial)
        {
            _context.BoqitemMaterial.Add(boqitemMaterial);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitemMaterial", new { id = boqitemMaterial.Boqitemmaterialid }, boqitemMaterial);
        }

        // DELETE: api/BoqitemMaterial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoqitemMaterial>> DeleteBoqitemMaterial(long id)
        {
            var boqitemMaterial = await _context.BoqitemMaterial.FindAsync(id);
            if (boqitemMaterial == null)
            {
                return NotFound();
            }

            _context.BoqitemMaterial.Remove(boqitemMaterial);
            await _context.SaveChangesAsync();

            return boqitemMaterial;
        }

        private bool BoqitemMaterialExists(long id)
        {
            return _context.BoqitemMaterial.Any(e => e.Boqitemmaterialid == id);
        }
    }
}
