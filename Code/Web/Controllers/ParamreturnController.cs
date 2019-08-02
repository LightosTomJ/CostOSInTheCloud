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
  public class ParamreturnsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Paramreturn> lParamreturns = db.Paramreturn.GetAllCompanyParamreturns(id);
          //return JsonConvert.SerializeObject(lParamreturns.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Paramreturn paramreturn)
      {
          //Create
          db.Paramreturn.Add(paramreturn);
          db.SaveChanges();
          return JsonConvert.SerializeObject(paramreturn);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Paramreturn paramreturn)
      {
          //Update
          db.Paramreturn.Update(paramreturn);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Paramreturn paramreturn)
      {
          db.Paramreturn.Remove(paramreturn);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
