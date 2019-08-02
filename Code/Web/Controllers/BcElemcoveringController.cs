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
  public class BcElemcoveringsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcElemcovering> lBcElemcoverings = db.BcElemcovering.GetAllCompanyBcElemcoverings(id);
          //return JsonConvert.SerializeObject(lBcElemcoverings.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcElemcovering bcelemcovering)
      {
          //Create
          db.BcElemcovering.Add(bcelemcovering);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcelemcovering);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcElemcovering bcelemcovering)
      {
          //Update
          db.BcElemcovering.Update(bcelemcovering);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcElemcovering bcelemcovering)
      {
          db.BcElemcovering.Remove(bcelemcovering);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
