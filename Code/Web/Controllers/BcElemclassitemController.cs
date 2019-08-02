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
  public class BcElemclassitemsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcElemclassitem> lBcElemclassitems = db.BcElemclassitem.GetAllCompanyBcElemclassitems(id);
          //return JsonConvert.SerializeObject(lBcElemclassitems.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcElemclassitem bcelemclassitem)
      {
          //Create
          db.BcElemclassitem.Add(bcelemclassitem);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcelemclassitem);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcElemclassitem bcelemclassitem)
      {
          //Update
          db.BcElemclassitem.Update(bcelemclassitem);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcElemclassitem bcelemclassitem)
      {
          db.BcElemclassitem.Remove(bcelemclassitem);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
