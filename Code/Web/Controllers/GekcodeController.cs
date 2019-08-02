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
  public class GekcodesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Gekcode> lGekcodes = db.Gekcode.GetAllCompanyGekcodes(id);
          //return JsonConvert.SerializeObject(lGekcodes.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Gekcode gekcode)
      {
          //Create
          db.Gekcode.Add(gekcode);
          db.SaveChanges();
          return JsonConvert.SerializeObject(gekcode);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Gekcode gekcode)
      {
          //Update
          db.Gekcode.Update(gekcode);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Gekcode gekcode)
      {
          db.Gekcode.Remove(gekcode);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
