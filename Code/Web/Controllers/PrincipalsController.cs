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
  public class PrincipalssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Principals> lPrincipalss = db.Principals.GetAllCompanyPrincipalss(id);
          //return JsonConvert.SerializeObject(lPrincipalss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Principals principals)
      {
          //Create
          db.Principals.Add(principals);
          db.SaveChanges();
          return JsonConvert.SerializeObject(principals);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Principals principals)
      {
          //Update
          db.Principals.Update(principals);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Principals principals)
      {
          db.Principals.Remove(principals);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
