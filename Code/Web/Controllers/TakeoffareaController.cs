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
  public class TakeoffareasController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Takeoffarea> lTakeoffareas = db.Takeoffarea.GetAllCompanyTakeoffareas(id);
          //return JsonConvert.SerializeObject(lTakeoffareas.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Takeoffarea takeoffarea)
      {
          //Create
          db.Takeoffarea.Add(takeoffarea);
          db.SaveChanges();
          return JsonConvert.SerializeObject(takeoffarea);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Takeoffarea takeoffarea)
      {
          //Update
          db.Takeoffarea.Update(takeoffarea);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Takeoffarea takeoffarea)
      {
          db.Takeoffarea.Remove(takeoffarea);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
