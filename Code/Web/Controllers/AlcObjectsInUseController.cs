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
  public class AlcObjectsInUsesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AlcObjectsInUse> lAlcObjectsInUses = db.AlcObjectsInUse.GetAllCompanyAlcObjectsInUses(id);
          //return JsonConvert.SerializeObject(lAlcObjectsInUses.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AlcObjectsInUse alcobjectsinuse)
      {
          //Create
          db.AlcObjectsInUse.Add(alcobjectsinuse);
          db.SaveChanges();
          return JsonConvert.SerializeObject(alcobjectsinuse);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AlcObjectsInUse alcobjectsinuse)
      {
          //Update
          db.AlcObjectsInUse.Update(alcobjectsinuse);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AlcObjectsInUse alcobjectsinuse)
      {
          db.AlcObjectsInUse.Remove(alcobjectsinuse);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
