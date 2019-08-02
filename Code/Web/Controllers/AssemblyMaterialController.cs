using Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Web.Controllers
{
  
  [Route("api/[controller]")]
  //[Authorize]
  [ApiController]
  public class AssemblyMaterialsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AssemblyMaterial> lAssemblyMaterials = db.AssemblyMaterial.GetAllCompanyAssemblyMaterials(id);
          //return JsonConvert.SerializeObject(lAssemblyMaterials.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AssemblyMaterial assemblymaterial)
      {
          //Create
          db.AssemblyMaterial.Add(assemblymaterial);
          db.SaveChanges();
          return JsonConvert.SerializeObject(assemblymaterial);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AssemblyMaterial assemblymaterial)
      {
          //Update
          db.AssemblyMaterial.Update(assemblymaterial);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AssemblyMaterial assemblymaterial)
      {
          db.AssemblyMaterial.Remove(assemblymaterial);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
