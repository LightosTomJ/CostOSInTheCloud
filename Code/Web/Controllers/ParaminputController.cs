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
  public class ParaminputsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Paraminput> lParaminputs = db.Paraminput.GetAllCompanyParaminputs(id);
          //return JsonConvert.SerializeObject(lParaminputs.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Paraminput paraminput)
      {
          //Create
          db.Paraminput.Add(paraminput);
          db.SaveChanges();
          return JsonConvert.SerializeObject(paraminput);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Paraminput paraminput)
      {
          //Update
          db.Paraminput.Update(paraminput);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Paraminput paraminput)
      {
          db.Paraminput.Remove(paraminput);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
