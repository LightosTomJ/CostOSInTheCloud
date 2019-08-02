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
  public class ProjecttemplatesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Projecttemplate> lProjecttemplates = db.Projecttemplate.GetAllCompanyProjecttemplates(id);
          //return JsonConvert.SerializeObject(lProjecttemplates.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Projecttemplate projecttemplate)
      {
          //Create
          db.Projecttemplate.Add(projecttemplate);
          db.SaveChanges();
          return JsonConvert.SerializeObject(projecttemplate);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Projecttemplate projecttemplate)
      {
          //Update
          db.Projecttemplate.Update(projecttemplate);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Projecttemplate projecttemplate)
      {
          db.Projecttemplate.Remove(projecttemplate);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
