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
  public class AlcUserSettingssController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AlcUserSettings> lAlcUserSettingss = db.AlcUserSettings.GetAllCompanyAlcUserSettingss(id);
          //return JsonConvert.SerializeObject(lAlcUserSettingss.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AlcUserSettings alcusersettings)
      {
          //Create
          db.AlcUserSettings.Add(alcusersettings);
          db.SaveChanges();
          return JsonConvert.SerializeObject(alcusersettings);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AlcUserSettings alcusersettings)
      {
          //Update
          db.AlcUserSettings.Update(alcusersettings);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AlcUserSettings alcusersettings)
      {
          db.AlcUserSettings.Remove(alcusersettings);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
