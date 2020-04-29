//using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using Models.DB.Local;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers.DB.Local
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : Controller
    {
        //Get relevant services
        private readonly Helper.DB.Local.MaterialsService materialService = new Helper.DB.Local.MaterialsService(new LocalContext());

        //Get local context
        private readonly LocalContext _context = new LocalContext();

        // GET: api/Materials
        [HttpGet]
        public async Task<ActionResult<string>> GetMaterials()
        //public async Task<ActionResult<IList<Material>>> GetMaterials()
        {
            IList<Material> materials = await materialService.GetAllMaterials();
            if (materials == null)
            {
                return BadRequest();
            }
            else if (materials.Count == 0)
            {
                return NoContent();
            }
            return JsonConvert.SerializeObject(materials.ToArray());
        }

        // GET: api/Materials/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Material>> GetMaterials(string id)
        {
            var material = await _context.Material.FindAsync(id);

            if (material == null)
            { 
                return BadRequest(); 
            }

            return material;
        }

        // PUT: api/Materials/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMaterials(long id, Material materials)
        {
            if (id != materials.MaterialId)
            {
                return BadRequest();
            }

            _context.Entry(materials).State = EntityState.Modified;

            if (await materialService.UpdateMaterial(materials) == false)
            {
                return NotFound();
            }

            return RedirectToAction();
        }

        // POST: api/Materials
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<IActionResult> PostMaterials(IList<Material> materials)
        {
            IList<long> lIds = await materialService.CreateMaterial(materials);
            IList<Material> AcceptedMaterials = new List<Material>();
            IList<Material> RejectedMaterials = new List<Material>();

            if (lIds.Count(j => j == -1) > 0)
            {
                for (int i = 0; i < materials.Count; i ++)
                {
                    if (lIds[i] == -1)
                    { RejectedMaterials.Add(materials[i]); }
                    else
                    { AcceptedMaterials.Add(materials[i]); }
                }
            }

            return RedirectToRoute("");
        }

        // DELETE: api/Materials/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMaterials(long id)
        {
            await materialService.DeleteMaterial(id);
            return Ok();
        }
    }
}
