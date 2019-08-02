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
  public class BcGrouppropsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcGroupprop> lBcGroupprops = db.BcGroupprop.GetAllCompanyBcGroupprops(id);
          //return JsonConvert.SerializeObject(lBcGroupprops.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcGroupprop bcgroupprop)
      {
          //Create
          db.BcGroupprop.Add(bcgroupprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcgroupprop);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcGroupprop bcgroupprop)
      {
          //Update
          db.BcGroupprop.Update(bcgroupprop);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcGroupprop bcgroupprop)
      {
          db.BcGroupprop.Remove(bcgroupprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
