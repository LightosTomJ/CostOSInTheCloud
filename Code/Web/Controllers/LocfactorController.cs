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
  public class LocfactorsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Locfactor> lLocfactors = db.Locfactor.GetAllCompanyLocfactors(id);
          //return JsonConvert.SerializeObject(lLocfactors.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Locfactor locfactor)
      {
          //Create
          db.Locfactor.Add(locfactor);
          db.SaveChanges();
          return JsonConvert.SerializeObject(locfactor);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Locfactor locfactor)
      {
          //Update
          db.Locfactor.Update(locfactor);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Locfactor locfactor)
      {
          db.Locfactor.Remove(locfactor);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
