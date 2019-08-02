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
  public class UnitaliassController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Unitalias> lUnitaliass = db.Unitalias.GetAllCompanyUnitaliass(id);
          //return JsonConvert.SerializeObject(lUnitaliass.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Unitalias unitalias)
      {
          //Create
          db.Unitalias.Add(unitalias);
          db.SaveChanges();
          return JsonConvert.SerializeObject(unitalias);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Unitalias unitalias)
      {
          //Update
          db.Unitalias.Update(unitalias);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Unitalias unitalias)
      {
          db.Unitalias.Remove(unitalias);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
