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
  public class FldfnsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Fldfn> lFldfns = db.Fldfn.GetAllCompanyFldfns(id);
          //return JsonConvert.SerializeObject(lFldfns.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Fldfn fldfn)
      {
          //Create
          db.Fldfn.Add(fldfn);
          db.SaveChanges();
          return JsonConvert.SerializeObject(fldfn);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Fldfn fldfn)
      {
          //Update
          db.Fldfn.Update(fldfn);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Fldfn fldfn)
      {
          db.Fldfn.Remove(fldfn);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
