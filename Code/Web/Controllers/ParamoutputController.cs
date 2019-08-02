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
  public class ParamoutputsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Paramoutput> lParamoutputs = db.Paramoutput.GetAllCompanyParamoutputs(id);
          //return JsonConvert.SerializeObject(lParamoutputs.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Paramoutput paramoutput)
      {
          //Create
          db.Paramoutput.Add(paramoutput);
          db.SaveChanges();
          return JsonConvert.SerializeObject(paramoutput);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Paramoutput paramoutput)
      {
          //Update
          db.Paramoutput.Update(paramoutput);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Paramoutput paramoutput)
      {
          db.Paramoutput.Remove(paramoutput);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
