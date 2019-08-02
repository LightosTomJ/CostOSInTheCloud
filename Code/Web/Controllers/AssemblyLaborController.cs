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
  public class AssemblyLaborsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AssemblyLabor> lAssemblyLabors = db.AssemblyLabor.GetAllCompanyAssemblyLabors(id);
          //return JsonConvert.SerializeObject(lAssemblyLabors.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AssemblyLabor assemblylabor)
      {
          //Create
          db.AssemblyLabor.Add(assemblylabor);
          db.SaveChanges();
          return JsonConvert.SerializeObject(assemblylabor);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AssemblyLabor assemblylabor)
      {
          //Update
          db.AssemblyLabor.Update(assemblylabor);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AssemblyLabor assemblylabor)
      {
          db.AssemblyLabor.Remove(assemblylabor);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
