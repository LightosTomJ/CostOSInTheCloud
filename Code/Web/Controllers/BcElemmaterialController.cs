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
  public class BcElemmaterialsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcElemmaterial> lBcElemmaterials = db.BcElemmaterial.GetAllCompanyBcElemmaterials(id);
          //return JsonConvert.SerializeObject(lBcElemmaterials.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcElemmaterial bcelemmaterial)
      {
          //Create
          db.BcElemmaterial.Add(bcelemmaterial);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcelemmaterial);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcElemmaterial bcelemmaterial)
      {
          //Update
          db.BcElemmaterial.Update(bcelemmaterial);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcElemmaterial bcelemmaterial)
      {
          db.BcElemmaterial.Remove(bcelemmaterial);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
