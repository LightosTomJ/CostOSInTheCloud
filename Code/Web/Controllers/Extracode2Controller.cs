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
  public class Extracode2sController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extracode2> lExtracode2s = db.Extracode2.GetAllCompanyExtracode2s(id);
          //return JsonConvert.SerializeObject(lExtracode2s.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extracode2 extracode2)
      {
          //Create
          db.Extracode2.Add(extracode2);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extracode2);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extracode2 extracode2)
      {
          //Update
          db.Extracode2.Update(extracode2);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extracode2 extracode2)
      {
          db.Extracode2.Remove(extracode2);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
