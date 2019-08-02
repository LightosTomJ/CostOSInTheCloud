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
  public class ProjectspecvarsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Projectspecvar> lProjectspecvars = db.Projectspecvar.GetAllCompanyProjectspecvars(id);
          //return JsonConvert.SerializeObject(lProjectspecvars.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Projectspecvar projectspecvar)
      {
          //Create
          db.Projectspecvar.Add(projectspecvar);
          db.SaveChanges();
          return JsonConvert.SerializeObject(projectspecvar);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Projectspecvar projectspecvar)
      {
          //Update
          db.Projectspecvar.Update(projectspecvar);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Projectspecvar projectspecvar)
      {
          db.Projectspecvar.Remove(projectspecvar);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
