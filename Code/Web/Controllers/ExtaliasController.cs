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
  public class ExtaliassController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extalias> lExtaliass = db.Extalias.GetAllCompanyExtaliass(id);
          //return JsonConvert.SerializeObject(lExtaliass.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extalias extalias)
      {
          //Create
          db.Extalias.Add(extalias);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extalias);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extalias extalias)
      {
          //Update
          db.Extalias.Update(extalias);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extalias extalias)
      {
          db.Extalias.Remove(extalias);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
