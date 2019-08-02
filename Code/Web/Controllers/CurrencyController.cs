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
  public class CurrencysController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Currency> lCurrencys = db.Currency.GetAllCompanyCurrencys(id);
          //return JsonConvert.SerializeObject(lCurrencys.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Currency currency)
      {
          //Create
          db.Currency.Add(currency);
          db.SaveChanges();
          return JsonConvert.SerializeObject(currency);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Currency currency)
      {
          //Update
          db.Currency.Update(currency);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Currency currency)
      {
          db.Currency.Remove(currency);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
