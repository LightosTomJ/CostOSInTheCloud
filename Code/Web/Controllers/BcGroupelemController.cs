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
  public class BcGroupelemsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcGroupelem> lBcGroupelems = db.BcGroupelem.GetAllCompanyBcGroupelems(id);
          //return JsonConvert.SerializeObject(lBcGroupelems.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcGroupelem bcgroupelem)
      {
          //Create
          db.BcGroupelem.Add(bcgroupelem);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcgroupelem);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcGroupelem bcgroupelem)
      {
          //Update
          db.BcGroupelem.Update(bcgroupelem);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcGroupelem bcgroupelem)
      {
          db.BcGroupelem.Remove(bcgroupelem);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
