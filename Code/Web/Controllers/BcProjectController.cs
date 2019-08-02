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
  public class BcProjectsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcProject> lBcProjects = db.BcProject.GetAllCompanyBcProjects(id);
          //return JsonConvert.SerializeObject(lBcProjects.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcProject bcproject)
      {
          //Create
          db.BcProject.Add(bcproject);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcproject);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcProject bcproject)
      {
          //Update
          db.BcProject.Update(bcproject);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcProject bcproject)
      {
          db.BcProject.Remove(bcproject);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
