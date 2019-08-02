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
  public class BcGpuserversController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcGpuserver> lBcGpuservers = db.BcGpuserver.GetAllCompanyBcGpuservers(id);
          //return JsonConvert.SerializeObject(lBcGpuservers.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcGpuserver bcgpuserver)
      {
          //Create
          db.BcGpuserver.Add(bcgpuserver);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcgpuserver);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcGpuserver bcgpuserver)
      {
          //Update
          db.BcGpuserver.Update(bcgpuserver);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcGpuserver bcgpuserver)
      {
          db.BcGpuserver.Remove(bcgpuserver);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
