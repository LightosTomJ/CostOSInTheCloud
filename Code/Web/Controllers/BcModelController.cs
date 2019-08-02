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
  public class BcModelsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcModel> lBcModels = db.BcModel.GetAllCompanyBcModels(id);
          //return JsonConvert.SerializeObject(lBcModels.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcModel bcmodel)
      {
          //Create
          db.BcModel.Add(bcmodel);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcmodel);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcModel bcmodel)
      {
          //Update
          db.BcModel.Update(bcmodel);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcModel bcmodel)
      {
          db.BcModel.Remove(bcmodel);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
