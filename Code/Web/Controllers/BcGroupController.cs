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
  public class BcGroupsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcGroup> lBcGroups = db.BcGroup.GetAllCompanyBcGroups(id);
          //return JsonConvert.SerializeObject(lBcGroups.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcGroup bcgroup)
      {
          //Create
          db.BcGroup.Add(bcgroup);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcgroup);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcGroup bcgroup)
      {
          //Update
          db.BcGroup.Update(bcgroup);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcGroup bcgroup)
      {
          db.BcGroup.Remove(bcgroup);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
