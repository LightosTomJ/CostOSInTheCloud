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
  public class AlcAmuserssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AlcAmusers> lAlcAmuserss = db.AlcAmusers.GetAllCompanyAlcAmuserss(id);
          //return JsonConvert.SerializeObject(lAlcAmuserss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AlcAmusers alcamusers)
      {
          //Create
          db.AlcAmusers.Add(alcamusers);
          db.SaveChanges();
          return JsonConvert.SerializeObject(alcamusers);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AlcAmusers alcamusers)
      {
          //Update
          db.AlcAmusers.Update(alcamusers);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AlcAmusers alcamusers)
      {
          db.AlcAmusers.Remove(alcamusers);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
