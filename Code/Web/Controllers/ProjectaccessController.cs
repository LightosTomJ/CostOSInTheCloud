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
  public class ProjectaccesssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Projectaccess> lProjectaccesss = db.Projectaccess.GetAllCompanyProjectaccesss(id);
          //return JsonConvert.SerializeObject(lProjectaccesss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Projectaccess projectaccess)
      {
          //Create
          db.Projectaccess.Add(projectaccess);
          db.SaveChanges();
          return JsonConvert.SerializeObject(projectaccess);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Projectaccess projectaccess)
      {
          //Update
          db.Projectaccess.Update(projectaccess);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Projectaccess projectaccess)
      {
          db.Projectaccess.Remove(projectaccess);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
