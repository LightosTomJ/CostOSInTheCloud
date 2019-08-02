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
  public class BcClassitemsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcClassitem> lBcClassitems = db.BcClassitem.GetAllCompanyBcClassitems(id);
          //return JsonConvert.SerializeObject(lBcClassitems.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcClassitem bcclassitem)
      {
          //Create
          db.BcClassitem.Add(bcclassitem);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcclassitem);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcClassitem bcclassitem)
      {
          //Update
          db.BcClassitem.Update(bcclassitem);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcClassitem bcclassitem)
      {
          db.BcClassitem.Remove(bcclassitem);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
