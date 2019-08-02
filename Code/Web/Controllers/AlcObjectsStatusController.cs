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
  public class AlcObjectsStatussController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AlcObjectsStatus> lAlcObjectsStatuss = db.AlcObjectsStatus.GetAllCompanyAlcObjectsStatuss(id);
          //return JsonConvert.SerializeObject(lAlcObjectsStatuss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AlcObjectsStatus alcobjectsstatus)
      {
          //Create
          db.AlcObjectsStatus.Add(alcobjectsstatus);
          db.SaveChanges();
          return JsonConvert.SerializeObject(alcobjectsstatus);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AlcObjectsStatus alcobjectsstatus)
      {
          //Update
          db.AlcObjectsStatus.Update(alcobjectsstatus);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AlcObjectsStatus alcobjectsstatus)
      {
          db.AlcObjectsStatus.Remove(alcobjectsstatus);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
