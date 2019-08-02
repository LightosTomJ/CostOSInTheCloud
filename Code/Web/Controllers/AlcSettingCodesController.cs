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
  public class AlcSettingCodessController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AlcSettingCodes> lAlcSettingCodess = db.AlcSettingCodes.GetAllCompanyAlcSettingCodess(id);
          //return JsonConvert.SerializeObject(lAlcSettingCodess.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AlcSettingCodes alcsettingcodes)
      {
          //Create
          db.AlcSettingCodes.Add(alcsettingcodes);
          db.SaveChanges();
          return JsonConvert.SerializeObject(alcsettingcodes);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AlcSettingCodes alcsettingcodes)
      {
          //Update
          db.AlcSettingCodes.Update(alcsettingcodes);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AlcSettingCodes alcsettingcodes)
      {
          db.AlcSettingCodes.Remove(alcsettingcodes);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
