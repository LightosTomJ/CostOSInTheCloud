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
  public class LocprofsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Locprof> lLocprofs = db.Locprof.GetAllCompanyLocprofs(id);
          //return JsonConvert.SerializeObject(lLocprofs.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Locprof locprof)
      {
          //Create
          db.Locprof.Add(locprof);
          db.SaveChanges();
          return JsonConvert.SerializeObject(locprof);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Locprof locprof)
      {
          //Update
          db.Locprof.Update(locprof);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Locprof locprof)
      {
          db.Locprof.Remove(locprof);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
