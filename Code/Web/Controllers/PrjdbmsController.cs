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
  public class PrjdbmssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Prjdbms> lPrjdbmss = db.Prjdbms.GetAllCompanyPrjdbmss(id);
          //return JsonConvert.SerializeObject(lPrjdbmss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Prjdbms prjdbms)
      {
          //Create
          db.Prjdbms.Add(prjdbms);
          db.SaveChanges();
          return JsonConvert.SerializeObject(prjdbms);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Prjdbms prjdbms)
      {
          //Update
          db.Prjdbms.Update(prjdbms);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Prjdbms prjdbms)
      {
          db.Prjdbms.Remove(prjdbms);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
