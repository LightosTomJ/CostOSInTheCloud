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
  public class AdsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Ad> lAds = db.Ad.GetAllCompanyAds(id);
          //return JsonConvert.SerializeObject(lAds.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Ad ad)
      {
          //Create
          db.Ad.Add(ad);
          db.SaveChanges();
          return JsonConvert.SerializeObject(ad);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Ad ad)
      {
          //Update
          db.Ad.Update(ad);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Ad ad)
      {
          db.Ad.Remove(ad);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
