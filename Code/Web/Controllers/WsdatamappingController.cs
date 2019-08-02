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
  public class WsdatamappingsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Wsdatamapping> lWsdatamappings = db.Wsdatamapping.GetAllCompanyWsdatamappings(id);
          //return JsonConvert.SerializeObject(lWsdatamappings.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Wsdatamapping wsdatamapping)
      {
          //Create
          db.Wsdatamapping.Add(wsdatamapping);
          db.SaveChanges();
          return JsonConvert.SerializeObject(wsdatamapping);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Wsdatamapping wsdatamapping)
      {
          //Update
          db.Wsdatamapping.Update(wsdatamapping);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Wsdatamapping wsdatamapping)
      {
          db.Wsdatamapping.Remove(wsdatamapping);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
