using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Results;

namespace ClientBlazor.Server.Controllers.Results
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialPartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public MaterialPartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/MaterialPartial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MaterialPartial>>> GetMaterialPartial()
        {
            return await _context.MaterialPartial.ToListAsync();
        }

        // GET: api/MaterialPartial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MaterialPartial>> GetMaterialPartial(int id)
        {
            var materialPartial = await _context.MaterialPartial.FindAsync(id);

            if (materialPartial == null)
            {
                return NotFound();
            }

            return materialPartial;
        }

        // PUT: api/MaterialPartial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterialPartial(int id, MaterialPartial materialPartial)
        {
            if (id != materialPartial.Id)
            {
                return BadRequest();
            }

            _context.Entry(materialPartial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialPartialExists(id))
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

        // POST: api/MaterialPartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<MaterialPartial>> PostMaterialPartial(MaterialPartial materialPartial)
        {
            _context.MaterialPartial.Add(materialPartial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MaterialPartialExists(materialPartial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMaterialPartial", new { id = materialPartial.Id }, materialPartial);
        }

        // DELETE: api/MaterialPartial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MaterialPartial>> DeleteMaterialPartial(int id)
        {
            var materialPartial = await _context.MaterialPartial.FindAsync(id);
            if (materialPartial == null)
            {
                return NotFound();
            }

            _context.MaterialPartial.Remove(materialPartial);
            await _context.SaveChangesAsync();

            return materialPartial;
        }

        private bool MaterialPartialExists(int id)
        {
            return _context.MaterialPartial.Any(e => e.Id == id);
        }
    }
}
