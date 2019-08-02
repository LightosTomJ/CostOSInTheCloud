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
  public class Extracode6sController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extracode6> lExtracode6s = db.Extracode6.GetAllCompanyExtracode6s(id);
          //return JsonConvert.SerializeObject(lExtracode6s.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extracode6 extracode6)
      {
          //Create
          db.Extracode6.Add(extracode6);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extracode6);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extracode6 extracode6)
      {
          //Update
          db.Extracode6.Update(extracode6);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extracode6 extracode6)
      {
          db.Extracode6.Remove(extracode6);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
