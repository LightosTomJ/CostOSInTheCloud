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
  public class PrjpropsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Prjprop> lPrjprops = db.Prjprop.GetAllCompanyPrjprops(id);
          //return JsonConvert.SerializeObject(lPrjprops.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Prjprop prjprop)
      {
          //Create
          db.Prjprop.Add(prjprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject(prjprop);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Prjprop prjprop)
      {
          //Update
          db.Prjprop.Update(prjprop);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Prjprop prjprop)
      {
          db.Prjprop.Remove(prjprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
