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
    public class BcSceneController : ControllerBase
    {
        private readonly localContext _context;

        public BcSceneController(localContext context)
        {
            _context = context;
        }

        // GET: api/BcScene
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BcScene>>> GetBcScene()
        {
            return await _context.BcScene.ToListAsync();
        }

        // GET: api/BcScene/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BcScene>> GetBcScene(long id)
        {
            var bcScene = await _context.BcScene.FindAsync(id);

            if (bcScene == null)
            {
                return NotFound();
            }

            return bcScene;
        }

        // PUT: api/BcScene/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBcScene(long id, BcScene bcScene)
        {
            if (id != bcScene.Id)
            {
                return BadRequest();
            }

            _context.Entry(bcScene).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BcSceneExists(id))
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

        // POST: api/BcScene
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<BcScene>> PostBcScene(BcScene bcScene)
        {
            _context.BcScene.Add(bcScene);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBcScene", new { id = bcScene.Id }, bcScene);
        }

        // DELETE: api/BcScene/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BcScene>> DeleteBcScene(long id)
        {
            var bcScene = await _context.BcScene.FindAsync(id);
            if (bcScene == null)
            {
                return NotFound();
            }

            _context.BcScene.Remove(bcScene);
            await _context.SaveChangesAsync();

            return bcScene;
        }

        private bool BcSceneExists(long id)
        {
            return _context.BcScene.Any(e => e.Id == id);
        }
    }
}
