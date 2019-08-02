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
  public class ExtdatasourcesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extdatasource> lExtdatasources = db.Extdatasource.GetAllCompanyExtdatasources(id);
          //return JsonConvert.SerializeObject(lExtdatasources.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extdatasource extdatasource)
      {
          //Create
          db.Extdatasource.Add(extdatasource);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extdatasource);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extdatasource extdatasource)
      {
          //Update
          db.Extdatasource.Update(extdatasource);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extdatasource extdatasource)
      {
          db.Extdatasource.Remove(extdatasource);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
