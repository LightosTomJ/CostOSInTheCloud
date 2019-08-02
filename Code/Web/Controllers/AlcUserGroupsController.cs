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
  public class AlcUserGroupssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AlcUserGroups> lAlcUserGroupss = db.AlcUserGroups.GetAllCompanyAlcUserGroupss(id);
          //return JsonConvert.SerializeObject(lAlcUserGroupss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AlcUserGroups alcusergroups)
      {
          //Create
          db.AlcUserGroups.Add(alcusergroups);
          db.SaveChanges();
          return JsonConvert.SerializeObject(alcusergroups);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AlcUserGroups alcusergroups)
      {
          //Update
          db.AlcUserGroups.Update(alcusergroups);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AlcUserGroups alcusergroups)
      {
          db.AlcUserGroups.Remove(alcusergroups);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
