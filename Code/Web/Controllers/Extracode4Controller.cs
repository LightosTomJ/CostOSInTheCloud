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
  public class Extracode4sController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extracode4> lExtracode4s = db.Extracode4.GetAllCompanyExtracode4s(id);
          //return JsonConvert.SerializeObject(lExtracode4s.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extracode4 extracode4)
      {
          //Create
          db.Extracode4.Add(extracode4);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extracode4);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extracode4 extracode4)
      {
          //Update
          db.Extracode4.Update(extracode4);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extracode4 extracode4)
      {
          db.Extracode4.Remove(extracode4);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
