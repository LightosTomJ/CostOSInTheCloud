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
  public class BcElementsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcElement> lBcElements = db.BcElement.GetAllCompanyBcElements(id);
          //return JsonConvert.SerializeObject(lBcElements.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcElement bcelement)
      {
          //Create
          db.BcElement.Add(bcelement);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcelement);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcElement bcelement)
      {
          //Update
          db.BcElement.Update(bcelement);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcElement bcelement)
      {
          db.BcElement.Remove(bcelement);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
