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
  public class TakeoffconsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Takeoffcon> lTakeoffcons = db.Takeoffcon.GetAllCompanyTakeoffcons(id);
          //return JsonConvert.SerializeObject(lTakeoffcons.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Takeoffcon takeoffcon)
      {
          //Create
          db.Takeoffcon.Add(takeoffcon);
          db.SaveChanges();
          return JsonConvert.SerializeObject(takeoffcon);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Takeoffcon takeoffcon)
      {
          //Update
          db.Takeoffcon.Update(takeoffcon);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Takeoffcon takeoffcon)
      {
          db.Takeoffcon.Remove(takeoffcon);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
