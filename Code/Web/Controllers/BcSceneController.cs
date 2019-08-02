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
  public class BcScenesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcScene> lBcScenes = db.BcScene.GetAllCompanyBcScenes(id);
          //return JsonConvert.SerializeObject(lBcScenes.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcScene bcscene)
      {
          //Create
          db.BcScene.Add(bcscene);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcscene);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcScene bcscene)
      {
          //Update
          db.BcScene.Update(bcscene);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcScene bcscene)
      {
          db.BcScene.Remove(bcscene);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
