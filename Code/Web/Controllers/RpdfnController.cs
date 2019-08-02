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
  public class RpdfnsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Rpdfn> lRpdfns = db.Rpdfn.GetAllCompanyRpdfns(id);
          //return JsonConvert.SerializeObject(lRpdfns.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Rpdfn rpdfn)
      {
          //Create
          db.Rpdfn.Add(rpdfn);
          db.SaveChanges();
          return JsonConvert.SerializeObject(rpdfn);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Rpdfn rpdfn)
      {
          //Update
          db.Rpdfn.Update(rpdfn);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Rpdfn rpdfn)
      {
          db.Rpdfn.Remove(rpdfn);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
