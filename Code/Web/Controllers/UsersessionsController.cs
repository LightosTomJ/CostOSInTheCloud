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
  public class UsersessionssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Usersessions> lUsersessionss = db.Usersessions.GetAllCompanyUsersessionss(id);
          //return JsonConvert.SerializeObject(lUsersessionss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Usersessions usersessions)
      {
          //Create
          db.Usersessions.Add(usersessions);
          db.SaveChanges();
          return JsonConvert.SerializeObject(usersessions);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Usersessions usersessions)
      {
          //Update
          db.Usersessions.Update(usersessions);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Usersessions usersessions)
      {
          db.Usersessions.Remove(usersessions);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
