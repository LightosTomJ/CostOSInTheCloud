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
  public class AssemblySubcontractorsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AssemblySubcontractor> lAssemblySubcontractors = db.AssemblySubcontractor.GetAllCompanyAssemblySubcontractors(id);
          //return JsonConvert.SerializeObject(lAssemblySubcontractors.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AssemblySubcontractor assemblysubcontractor)
      {
          //Create
          db.AssemblySubcontractor.Add(assemblysubcontractor);
          db.SaveChanges();
          return JsonConvert.SerializeObject(assemblysubcontractor);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AssemblySubcontractor assemblysubcontractor)
      {
          //Update
          db.AssemblySubcontractor.Update(assemblysubcontractor);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AssemblySubcontractor assemblysubcontractor)
      {
          db.AssemblySubcontractor.Remove(assemblysubcontractor);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
