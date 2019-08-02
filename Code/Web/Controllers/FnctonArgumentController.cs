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
  public class FnctonArgumentsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<FnctonArgument> lFnctonArguments = db.FnctonArgument.GetAllCompanyFnctonArguments(id);
          //return JsonConvert.SerializeObject(lFnctonArguments.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]FnctonArgument fnctonargument)
      {
          //Create
          db.FnctonArgument.Add(fnctonargument);
          db.SaveChanges();
          return JsonConvert.SerializeObject(fnctonargument);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]FnctonArgument fnctonargument)
      {
          //Update
          db.FnctonArgument.Update(fnctonargument);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]FnctonArgument fnctonargument)
      {
          db.FnctonArgument.Remove(fnctonargument);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
