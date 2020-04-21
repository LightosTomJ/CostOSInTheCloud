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
    public class BcModelController : ControllerBase
    {
        private readonly localContext _context;

        public BcModelController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcModel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcModel>>> GetBcModel()
        {
            return await _context.BcModel.ToListAsync();
        }

        // GET: api/BcModel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcModel>> GetBcModel(long id)
        {
            var bcModel = await _context.BcModel.FindAsync(id);

            if (bcModel == null)
            {
                return NotFound();
            }

            return bcModel;
        }

        // PUT: api/BcModel/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcModel(long id, BcModel bcModel)
        {
            if (id != bcModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcModelExists(id))
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

        // POST: api/BcModel
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BcModel>> PostBcModel(BcModel bcModel)
        {
            _context.BcModel.Add(bcModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcModel", new { id = bcModel.Id }, bcModel);
        }

        // DELETE: api/BcModel/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcModel>> DeleteBcModel(long id)
        {
            var bcModel = await _context.BcModel.FindAsync(id);
            if (bcModel == null)
            {
                return NotFound();
            }

            _context.BcModel.Remove(bcModel);
            await _context.SaveChangesAsync();

            return bcModel;
        }

        private bool BcModelExists(long id)
        {
            return _context.BcModel.Any(e => e.Id == id);
        }
    }
}
