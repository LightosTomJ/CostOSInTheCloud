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
  public class ProjectusersController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Projectuser> lProjectusers = db.Projectuser.GetAllCompanyProjectusers(id);
          //return JsonConvert.SerializeObject(lProjectusers.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Projectuser projectuser)
      {
          //Create
          db.Projectuser.Add(projectuser);
          db.SaveChanges();
          return JsonConvert.SerializeObject(projectuser);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Projectuser projectuser)
      {
          //Update
          db.Projectuser.Update(projectuser);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Projectuser projectuser)
      {
          db.Projectuser.Remove(projectuser);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
