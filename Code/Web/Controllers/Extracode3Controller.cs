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
  public class Extracode3sController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extracode3> lExtracode3s = db.Extracode3.GetAllCompanyExtracode3s(id);
          //return JsonConvert.SerializeObject(lExtracode3s.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extracode3 extracode3)
      {
          //Create
          db.Extracode3.Add(extracode3);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extracode3);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extracode3 extracode3)
      {
          //Update
          db.Extracode3.Update(extracode3);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extracode3 extracode3)
      {
          db.Extracode3.Remove(extracode3);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
