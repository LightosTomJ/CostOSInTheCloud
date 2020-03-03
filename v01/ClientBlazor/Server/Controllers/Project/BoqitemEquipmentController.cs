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
    public class BoqitemEquipmentController : ControllerBase
    {
        private readonly projectContext _context;

        public BoqitemEquipmentController(projectContext context)
        {
            _context = context;
        }

        // GET: api/BoqitemEquipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoqitemEquipment>>> GetBoqitemEquipment()
        {
            return await _context.BoqitemEquipment.ToListAsync();
        }

        // GET: api/BoqitemEquipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoqitemEquipment>> GetBoqitemEquipment(long id)
        {
            var boqitemEquipment = await _context.BoqitemEquipment.FindAsync(id);

            if (boqitemEquipment == null)
            {
                return NotFound();
            }

            return boqitemEquipment;
        }

        // PUT: api/BoqitemEquipment/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBoqitemEquipment(long id, BoqitemEquipment boqitemEquipment)
        {
            if (id != boqitemEquipment.Boqitemequipmentid)
            {
                return BadRequest();
            }

            _context.Entry(boqitemEquipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BoqitemEquipmentExists(id))
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

        // POST: api/BoqitemEquipment
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BoqitemEquipment>> PostBoqitemEquipment(BoqitemEquipment boqitemEquipment)
        {
            _context.BoqitemEquipment.Add(boqitemEquipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBoqitemEquipment", new { id = boqitemEquipment.Boqitemequipmentid }, boqitemEquipment);
        }

        // DELETE: api/BoqitemEquipment/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BoqitemEquipment>> DeleteBoqitemEquipment(long id)
        {
            var boqitemEquipment = await _context.BoqitemEquipment.FindAsync(id);
            if (boqitemEquipment == null)
            {
                return NotFound();
            }

            _context.BoqitemEquipment.Remove(boqitemEquipment);
            await _context.SaveChangesAsync();

            return boqitemEquipment;
        }

        private bool BoqitemEquipmentExists(long id)
        {
            return _context.BoqitemEquipment.Any(e => e.Boqitemequipmentid == id);
        }
    }
}
