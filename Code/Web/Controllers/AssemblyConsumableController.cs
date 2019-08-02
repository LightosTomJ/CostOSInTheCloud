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
  public class AssemblyConsumablesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AssemblyConsumable> lAssemblyConsumables = db.AssemblyConsumable.GetAllCompanyAssemblyConsumables(id);
          //return JsonConvert.SerializeObject(lAssemblyConsumables.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AssemblyConsumable assemblyconsumable)
      {
          //Create
          db.AssemblyConsumable.Add(assemblyconsumable);
          db.SaveChanges();
          return JsonConvert.SerializeObject(assemblyconsumable);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AssemblyConsumable assemblyconsumable)
      {
          //Update
          db.AssemblyConsumable.Update(assemblyconsumable);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AssemblyConsumable assemblyconsumable)
      {
          db.AssemblyConsumable.Remove(assemblyconsumable);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
