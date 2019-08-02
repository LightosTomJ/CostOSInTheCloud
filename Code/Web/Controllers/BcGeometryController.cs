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
  public class BcGeometrysController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcGeometry> lBcGeometrys = db.BcGeometry.GetAllCompanyBcGeometrys(id);
          //return JsonConvert.SerializeObject(lBcGeometrys.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcGeometry bcgeometry)
      {
          //Create
          db.BcGeometry.Add(bcgeometry);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcgeometry);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcGeometry bcgeometry)
      {
          //Update
          db.BcGeometry.Update(bcgeometry);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcGeometry bcgeometry)
      {
          db.BcGeometry.Remove(bcgeometry);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
