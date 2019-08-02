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
  public class AssemblysController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Assembly> lAssemblys = db.Assembly.GetAllCompanyAssemblys(id);
          //return JsonConvert.SerializeObject(lAssemblys.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Assembly assembly)
      {
          //Create
          db.Assembly.Add(assembly);
          db.SaveChanges();
          return JsonConvert.SerializeObject(assembly);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Assembly assembly)
      {
          //Update
          db.Assembly.Update(assembly);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Assembly assembly)
      {
          db.Assembly.Remove(assembly);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
