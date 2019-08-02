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
  public class SubcontractorsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Subcontractor> lSubcontractors = db.Subcontractor.GetAllCompanySubcontractors(id);
          //return JsonConvert.SerializeObject(lSubcontractors.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Subcontractor subcontractor)
      {
          //Create
          db.Subcontractor.Add(subcontractor);
          db.SaveChanges();
          return JsonConvert.SerializeObject(subcontractor);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Subcontractor subcontractor)
      {
          //Update
          db.Subcontractor.Update(subcontractor);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Subcontractor subcontractor)
      {
          db.Subcontractor.Remove(subcontractor);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
