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
  public class BcSpatialinfosController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcSpatialinfo> lBcSpatialinfos = db.BcSpatialinfo.GetAllCompanyBcSpatialinfos(id);
          //return JsonConvert.SerializeObject(lBcSpatialinfos.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcSpatialinfo bcspatialinfo)
      {
          //Create
          db.BcSpatialinfo.Add(bcspatialinfo);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcspatialinfo);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcSpatialinfo bcspatialinfo)
      {
          //Update
          db.BcSpatialinfo.Update(bcspatialinfo);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcSpatialinfo bcspatialinfo)
      {
          db.BcSpatialinfo.Remove(bcspatialinfo);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
