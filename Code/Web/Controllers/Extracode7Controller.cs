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
  public class Extracode7sController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extracode7> lExtracode7s = db.Extracode7.GetAllCompanyExtracode7s(id);
          //return JsonConvert.SerializeObject(lExtracode7s.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extracode7 extracode7)
      {
          //Create
          db.Extracode7.Add(extracode7);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extracode7);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extracode7 extracode7)
      {
          //Update
          db.Extracode7.Update(extracode7);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extracode7 extracode7)
      {
          db.Extracode7.Remove(extracode7);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
