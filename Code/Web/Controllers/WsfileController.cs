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
  public class WsfilesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Wsfile> lWsfiles = db.Wsfile.GetAllCompanyWsfiles(id);
          //return JsonConvert.SerializeObject(lWsfiles.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Wsfile wsfile)
      {
          //Create
          db.Wsfile.Add(wsfile);
          db.SaveChanges();
          return JsonConvert.SerializeObject(wsfile);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Wsfile wsfile)
      {
          //Update
          db.Wsfile.Update(wsfile);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Wsfile wsfile)
      {
          db.Wsfile.Remove(wsfile);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
