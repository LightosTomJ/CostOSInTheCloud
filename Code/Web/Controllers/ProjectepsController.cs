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
  public class ProjectepssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Projecteps> lProjectepss = db.Projecteps.GetAllCompanyProjectepss(id);
          //return JsonConvert.SerializeObject(lProjectepss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Projecteps projecteps)
      {
          //Create
          db.Projecteps.Add(projecteps);
          db.SaveChanges();
          return JsonConvert.SerializeObject(projecteps);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Projecteps projecteps)
      {
          //Update
          db.Projecteps.Update(projecteps);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Projecteps projecteps)
      {
          db.Projecteps.Remove(projecteps);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
