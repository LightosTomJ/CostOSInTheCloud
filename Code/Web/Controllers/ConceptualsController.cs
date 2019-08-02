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
  public class ConceptualssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Conceptuals> lConceptualss = db.Conceptuals.GetAllCompanyConceptualss(id);
          //return JsonConvert.SerializeObject(lConceptualss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Conceptuals conceptuals)
      {
          //Create
          db.Conceptuals.Add(conceptuals);
          db.SaveChanges();
          return JsonConvert.SerializeObject(conceptuals);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Conceptuals conceptuals)
      {
          //Update
          db.Conceptuals.Update(conceptuals);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Conceptuals conceptuals)
      {
          db.Conceptuals.Remove(conceptuals);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
