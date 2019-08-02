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
  public class RolessController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Roles> lRoless = db.Roles.GetAllCompanyRoless(id);
          //return JsonConvert.SerializeObject(lRoless.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Roles roles)
      {
          //Create
          db.Roles.Add(roles);
          db.SaveChanges();
          return JsonConvert.SerializeObject(roles);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Roles roles)
      {
          //Update
          db.Roles.Update(roles);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Roles roles)
      {
          db.Roles.Remove(roles);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
