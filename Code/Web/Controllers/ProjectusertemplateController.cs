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
  public class ProjectusertemplatesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Projectusertemplate> lProjectusertemplates = db.Projectusertemplate.GetAllCompanyProjectusertemplates(id);
          //return JsonConvert.SerializeObject(lProjectusertemplates.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Projectusertemplate projectusertemplate)
      {
          //Create
          db.Projectusertemplate.Add(projectusertemplate);
          db.SaveChanges();
          return JsonConvert.SerializeObject(projectusertemplate);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Projectusertemplate projectusertemplate)
      {
          //Update
          db.Projectusertemplate.Update(projectusertemplate);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Projectusertemplate projectusertemplate)
      {
          db.Projectusertemplate.Remove(projectusertemplate);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
