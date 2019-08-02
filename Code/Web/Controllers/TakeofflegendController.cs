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
  public class TakeofflegendsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Takeofflegend> lTakeofflegends = db.Takeofflegend.GetAllCompanyTakeofflegends(id);
          //return JsonConvert.SerializeObject(lTakeofflegends.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Takeofflegend takeofflegend)
      {
          //Create
          db.Takeofflegend.Add(takeofflegend);
          db.SaveChanges();
          return JsonConvert.SerializeObject(takeofflegend);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Takeofflegend takeofflegend)
      {
          //Update
          db.Takeofflegend.Update(takeofflegend);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Takeofflegend takeofflegend)
      {
          db.Takeofflegend.Remove(takeofflegend);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
