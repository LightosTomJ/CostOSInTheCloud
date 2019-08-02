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
  public class UserpropsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Userprop> lUserprops = db.Userprop.GetAllCompanyUserprops(id);
          //return JsonConvert.SerializeObject(lUserprops.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Userprop userprop)
      {
          //Create
          db.Userprop.Add(userprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject(userprop);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Userprop userprop)
      {
          //Update
          db.Userprop.Update(userprop);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Userprop userprop)
      {
          db.Userprop.Remove(userprop);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
