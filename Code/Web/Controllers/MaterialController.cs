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
  public class MaterialsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Material> lMaterials = db.Material.GetAllCompanyMaterials(id);
          //return JsonConvert.SerializeObject(lMaterials.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Material material)
      {
          //Create
          db.Material.Add(material);
          db.SaveChanges();
          return JsonConvert.SerializeObject(material);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Material material)
      {
          //Update
          db.Material.Update(material);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Material material)
      {
          db.Material.Remove(material);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
