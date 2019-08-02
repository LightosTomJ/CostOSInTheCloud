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
  public class LictblsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Lictbl> lLictbls = db.Lictbl.GetAllCompanyLictbls(id);
          //return JsonConvert.SerializeObject(lLictbls.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Lictbl lictbl)
      {
          //Create
          db.Lictbl.Add(lictbl);
          db.SaveChanges();
          return JsonConvert.SerializeObject(lictbl);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Lictbl lictbl)
      {
          //Update
          db.Lictbl.Update(lictbl);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Lictbl lictbl)
      {
          db.Lictbl.Remove(lictbl);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
