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
  public class BcQuantitysController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<BcQuantity> lBcQuantitys = db.BcQuantity.GetAllCompanyBcQuantitys(id);
          //return JsonConvert.SerializeObject(lBcQuantitys.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]BcQuantity bcquantity)
      {
          //Create
          db.BcQuantity.Add(bcquantity);
          db.SaveChanges();
          return JsonConvert.SerializeObject(bcquantity);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]BcQuantity bcquantity)
      {
          //Update
          db.BcQuantity.Update(bcquantity);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]BcQuantity bcquantity)
      {
          db.BcQuantity.Remove(bcquantity);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
