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
  public class BcElemconnectionsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcElemconnection> lBcElemconnections = db.BcElemconnection.GetAllCompanyBcElemconnections(id);
          //return JsonConvert.SerializeObject(lBcElemconnections.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcElemconnection bcelemconnection)
      {
          //Create
          db.BcElemconnection.Add(bcelemconnection);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcelemconnection);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcElemconnection bcelemconnection)
      {
          //Update
          db.BcElemconnection.Update(bcelemconnection);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcElemconnection bcelemconnection)
      {
          db.BcElemconnection.Remove(bcelemconnection);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
