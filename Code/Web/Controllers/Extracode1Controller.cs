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
  public class Extracode1sController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extracode1> lExtracode1s = db.Extracode1.GetAllCompanyExtracode1s(id);
          //return JsonConvert.SerializeObject(lExtracode1s.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extracode1 extracode1)
      {
          //Create
          db.Extracode1.Add(extracode1);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extracode1);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extracode1 extracode1)
      {
          //Update
          db.Extracode1.Update(extracode1);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extracode1 extracode1)
      {
          db.Extracode1.Remove(extracode1);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
