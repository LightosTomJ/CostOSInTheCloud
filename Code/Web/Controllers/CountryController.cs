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
  public class CountrysController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Country> lCountrys = db.Country.GetAllCompanyCountrys(id);
          //return JsonConvert.SerializeObject(lCountrys.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Country country)
      {
          //Create
          db.Country.Add(country);
          db.SaveChanges();
          return JsonConvert.SerializeObject(country);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Country country)
      {
          //Update
          db.Country.Update(country);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Country country)
      {
          db.Country.Remove(country);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
