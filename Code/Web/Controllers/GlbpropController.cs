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
  public class GlbpropsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Glbprop> lGlbprops = db.Glbprop.GetAllCompanyGlbprops(id);
          //return JsonConvert.SerializeObject(lGlbprops.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Glbprop glbprop)
      {
          //Create
          db.Glbprop.Add(glbprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject(glbprop);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Glbprop glbprop)
      {
          //Update
          db.Glbprop.Update(glbprop);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Glbprop glbprop)
      {
          db.Glbprop.Remove(glbprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
