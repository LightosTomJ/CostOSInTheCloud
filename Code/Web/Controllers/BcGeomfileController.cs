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
  public class BcGeomfilesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcGeomfile> lBcGeomfiles = db.BcGeomfile.GetAllCompanyBcGeomfiles(id);
          //return JsonConvert.SerializeObject(lBcGeomfiles.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcGeomfile bcgeomfile)
      {
          //Create
          db.BcGeomfile.Add(bcgeomfile);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcgeomfile);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcGeomfile bcgeomfile)
      {
          //Update
          db.BcGeomfile.Update(bcgeomfile);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcGeomfile bcgeomfile)
      {
          db.BcGeomfile.Remove(bcgeomfile);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
