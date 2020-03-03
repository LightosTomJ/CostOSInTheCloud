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
    public class SupplierPartialController : ControllerBase
    {
        private readonly resultsContext _context;

        public SupplierPartialController(resultsContext context)
        {
            _context = context;
        }

        // GET: api/SupplierPartial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierPartial>>> GetSupplierPartial()
        {
            return await _context.SupplierPartial.ToListAsync();
        }

        // GET: api/SupplierPartial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierPartial>> GetSupplierPartial(int id)
        {
            var supplierPartial = await _context.SupplierPartial.FindAsync(id);

            if (supplierPartial == null)
            {
                return NotFound();
            }

            return supplierPartial;
        }

        // PUT: api/SupplierPartial/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplierPartial(int id, SupplierPartial supplierPartial)
        {
            if (id != supplierPartial.Id)
            {
                return BadRequest();
            }

            _context.Entry(supplierPartial).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierPartialExists(id))
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

        // POST: api/SupplierPartial
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<SupplierPartial>> PostSupplierPartial(SupplierPartial supplierPartial)
        {
            _context.SupplierPartial.Add(supplierPartial);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SupplierPartialExists(supplierPartial.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSupplierPartial", new { id = supplierPartial.Id }, supplierPartial);
        }

        // DELETE: api/SupplierPartial/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierPartial>> DeleteSupplierPartial(int id)
        {
            var supplierPartial = await _context.SupplierPartial.FindAsync(id);
            if (supplierPartial == null)
            {
                return NotFound();
            }

            _context.SupplierPartial.Remove(supplierPartial);
            await _context.SaveChangesAsync();

            return supplierPartial;
        }

        private bool SupplierPartialExists(int id)
        {
            return _context.SupplierPartial.Any(e => e.Id == id);
        }
    }
}
