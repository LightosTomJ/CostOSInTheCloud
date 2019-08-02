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
  public class RatebuildupcolssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Ratebuildupcols> lRatebuildupcolss = db.Ratebuildupcols.GetAllCompanyRatebuildupcolss(id);
          //return JsonConvert.SerializeObject(lRatebuildupcolss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Ratebuildupcols ratebuildupcols)
      {
          //Create
          db.Ratebuildupcols.Add(ratebuildupcols);
          db.SaveChanges();
          return JsonConvert.SerializeObject(ratebuildupcols);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Ratebuildupcols ratebuildupcols)
      {
          //Update
          db.Ratebuildupcols.Update(ratebuildupcols);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Ratebuildupcols ratebuildupcols)
      {
          db.Ratebuildupcols.Remove(ratebuildupcols);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
