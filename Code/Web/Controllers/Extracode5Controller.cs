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
  public class Extracode5sController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extracode5> lExtracode5s = db.Extracode5.GetAllCompanyExtracode5s(id);
          //return JsonConvert.SerializeObject(lExtracode5s.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extracode5 extracode5)
      {
          //Create
          db.Extracode5.Add(extracode5);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extracode5);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extracode5 extracode5)
      {
          //Update
          db.Extracode5.Update(extracode5);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extracode5 extracode5)
      {
          db.Extracode5.Remove(extracode5);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
