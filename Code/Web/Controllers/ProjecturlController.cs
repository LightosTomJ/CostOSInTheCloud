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
  public class ProjecturlsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Projecturl> lProjecturls = db.Projecturl.GetAllCompanyProjecturls(id);
          //return JsonConvert.SerializeObject(lProjecturls.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Projecturl projecturl)
      {
          //Create
          db.Projecturl.Add(projecturl);
          db.SaveChanges();
          return JsonConvert.SerializeObject(projecturl);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Projecturl projecturl)
      {
          //Update
          db.Projecturl.Update(projecturl);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Projecturl projecturl)
      {
          db.Projecturl.Remove(projecturl);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
