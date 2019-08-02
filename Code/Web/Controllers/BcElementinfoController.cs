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
  public class BcElementinfosController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcElementinfo> lBcElementinfos = db.BcElementinfo.GetAllCompanyBcElementinfos(id);
          //return JsonConvert.SerializeObject(lBcElementinfos.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcElementinfo bcelementinfo)
      {
          //Create
          db.BcElementinfo.Add(bcelementinfo);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcelementinfo);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcElementinfo bcelementinfo)
      {
          //Update
          db.BcElementinfo.Update(bcelementinfo);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcElementinfo bcelementinfo)
      {
          db.BcElementinfo.Remove(bcelementinfo);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
