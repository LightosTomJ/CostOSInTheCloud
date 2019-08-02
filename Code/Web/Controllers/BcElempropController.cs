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
  public class BcElempropsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcElemprop> lBcElemprops = db.BcElemprop.GetAllCompanyBcElemprops(id);
          //return JsonConvert.SerializeObject(lBcElemprops.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcElemprop bcelemprop)
      {
          //Create
          db.BcElemprop.Add(bcelemprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcelemprop);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcElemprop bcelemprop)
      {
          //Update
          db.BcElemprop.Update(bcelemprop);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcElemprop bcelemprop)
      {
          db.BcElemprop.Remove(bcelemprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
