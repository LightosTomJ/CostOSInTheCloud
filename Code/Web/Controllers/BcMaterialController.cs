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
  public class BcMaterialsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcMaterial> lBcMaterials = db.BcMaterial.GetAllCompanyBcMaterials(id);
          //return JsonConvert.SerializeObject(lBcMaterials.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcMaterial bcmaterial)
      {
          //Create
          db.BcMaterial.Add(bcmaterial);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcmaterial);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcMaterial bcmaterial)
      {
          //Update
          db.BcMaterial.Update(bcmaterial);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcMaterial bcmaterial)
      {
          db.BcMaterial.Remove(bcmaterial);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
