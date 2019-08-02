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
  public class TakeofftrianglesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Takeofftriangle> lTakeofftriangles = db.Takeofftriangle.GetAllCompanyTakeofftriangles(id);
          //return JsonConvert.SerializeObject(lTakeofftriangles.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Takeofftriangle takeofftriangle)
      {
          //Create
          db.Takeofftriangle.Add(takeofftriangle);
          db.SaveChanges();
          return JsonConvert.SerializeObject(takeofftriangle);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Takeofftriangle takeofftriangle)
      {
          //Update
          db.Takeofftriangle.Update(takeofftriangle);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Takeofftriangle takeofftriangle)
      {
          db.Takeofftriangle.Remove(takeofftriangle);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
