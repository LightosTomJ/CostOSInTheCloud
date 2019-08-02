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
  public class TeamaliassController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Teamalias> lTeamaliass = db.Teamalias.GetAllCompanyTeamaliass(id);
          //return JsonConvert.SerializeObject(lTeamaliass.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Teamalias teamalias)
      {
          //Create
          db.Teamalias.Add(teamalias);
          db.SaveChanges();
          return JsonConvert.SerializeObject(teamalias);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Teamalias teamalias)
      {
          //Update
          db.Teamalias.Update(teamalias);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Teamalias teamalias)
      {
          db.Teamalias.Remove(teamalias);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
