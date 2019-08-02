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
  public class LaborsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Labor> lLabors = db.Labor.GetAllCompanyLabors(id);
          //return JsonConvert.SerializeObject(lLabors.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Labor labor)
      {
          //Create
          db.Labor.Add(labor);
          db.SaveChanges();
          return JsonConvert.SerializeObject(labor);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Labor labor)
      {
          //Update
          db.Labor.Update(labor);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Labor labor)
      {
          db.Labor.Remove(labor);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
