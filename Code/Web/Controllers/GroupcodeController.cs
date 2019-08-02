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
  public class GroupcodesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Groupcode> lGroupcodes = db.Groupcode.GetAllCompanyGroupcodes(id);
          //return JsonConvert.SerializeObject(lGroupcodes.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Groupcode groupcode)
      {
          //Create
          db.Groupcode.Add(groupcode);
          db.SaveChanges();
          return JsonConvert.SerializeObject(groupcode);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Groupcode groupcode)
      {
          //Update
          db.Groupcode.Update(groupcode);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Groupcode groupcode)
      {
          db.Groupcode.Remove(groupcode);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
