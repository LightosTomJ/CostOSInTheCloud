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
  public class LayoutcsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Layoutc> lLayoutcs = db.Layoutc.GetAllCompanyLayoutcs(id);
          //return JsonConvert.SerializeObject(lLayoutcs.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Layoutc layoutc)
      {
          //Create
          db.Layoutc.Add(layoutc);
          db.SaveChanges();
          return JsonConvert.SerializeObject(layoutc);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Layoutc layoutc)
      {
          //Update
          db.Layoutc.Update(layoutc);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Layoutc layoutc)
      {
          db.Layoutc.Remove(layoutc);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
