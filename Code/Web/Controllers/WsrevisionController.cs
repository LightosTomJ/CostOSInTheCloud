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
  public class WsrevisionsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Wsrevision> lWsrevisions = db.Wsrevision.GetAllCompanyWsrevisions(id);
          //return JsonConvert.SerializeObject(lWsrevisions.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Wsrevision wsrevision)
      {
          //Create
          db.Wsrevision.Add(wsrevision);
          db.SaveChanges();
          return JsonConvert.SerializeObject(wsrevision);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Wsrevision wsrevision)
      {
          //Update
          db.Wsrevision.Update(wsrevision);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Wsrevision wsrevision)
      {
          db.Wsrevision.Remove(wsrevision);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
