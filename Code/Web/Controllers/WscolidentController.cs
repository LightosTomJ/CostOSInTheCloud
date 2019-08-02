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
  public class WscolidentsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Wscolident> lWscolidents = db.Wscolident.GetAllCompanyWscolidents(id);
          //return JsonConvert.SerializeObject(lWscolidents.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Wscolident wscolident)
      {
          //Create
          db.Wscolident.Add(wscolident);
          db.SaveChanges();
          return JsonConvert.SerializeObject(wscolident);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Wscolident wscolident)
      {
          //Update
          db.Wscolident.Update(wscolident);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Wscolident wscolident)
      {
          db.Wscolident.Remove(wscolident);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
