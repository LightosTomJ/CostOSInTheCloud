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
  public class TakeoffpointsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Takeoffpoint> lTakeoffpoints = db.Takeoffpoint.GetAllCompanyTakeoffpoints(id);
          //return JsonConvert.SerializeObject(lTakeoffpoints.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Takeoffpoint takeoffpoint)
      {
          //Create
          db.Takeoffpoint.Add(takeoffpoint);
          db.SaveChanges();
          return JsonConvert.SerializeObject(takeoffpoint);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Takeoffpoint takeoffpoint)
      {
          //Update
          db.Takeoffpoint.Update(takeoffpoint);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Takeoffpoint takeoffpoint)
      {
          db.Takeoffpoint.Remove(takeoffpoint);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
