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
  public class AlcGroupssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AlcGroups> lAlcGroupss = db.AlcGroups.GetAllCompanyAlcGroupss(id);
          //return JsonConvert.SerializeObject(lAlcGroupss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AlcGroups alcgroups)
      {
          //Create
          db.AlcGroups.Add(alcgroups);
          db.SaveChanges();
          return JsonConvert.SerializeObject(alcgroups);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AlcGroups alcgroups)
      {
          //Update
          db.AlcGroups.Update(alcgroups);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AlcGroups alcgroups)
      {
          db.AlcGroups.Remove(alcgroups);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
