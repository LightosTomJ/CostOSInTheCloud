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
  public class FnctonsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Fncton> lFnctons = db.Fncton.GetAllCompanyFnctons(id);
          //return JsonConvert.SerializeObject(lFnctons.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Fncton fncton)
      {
          //Create
          db.Fncton.Add(fncton);
          db.SaveChanges();
          return JsonConvert.SerializeObject(fncton);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Fncton fncton)
      {
          //Update
          db.Fncton.Update(fncton);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Fncton fncton)
      {
          db.Fncton.Remove(fncton);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
