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
  public class ConsumablesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Consumable> lConsumables = db.Consumable.GetAllCompanyConsumables(id);
          //return JsonConvert.SerializeObject(lConsumables.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Consumable consumable)
      {
          //Create
          db.Consumable.Add(consumable);
          db.SaveChanges();
          return JsonConvert.SerializeObject(consumable);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Consumable consumable)
      {
          //Update
          db.Consumable.Update(consumable);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Consumable consumable)
      {
          db.Consumable.Remove(consumable);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
