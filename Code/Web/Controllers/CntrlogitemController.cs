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
  public class CntrlogitemsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Cntrlogitem> lCntrlogitems = db.Cntrlogitem.GetAllCompanyCntrlogitems(id);
          //return JsonConvert.SerializeObject(lCntrlogitems.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Cntrlogitem cntrlogitem)
      {
          //Create
          db.Cntrlogitem.Add(cntrlogitem);
          db.SaveChanges();
          return JsonConvert.SerializeObject(cntrlogitem);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Cntrlogitem cntrlogitem)
      {
          //Update
          db.Cntrlogitem.Update(cntrlogitem);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Cntrlogitem cntrlogitem)
      {
          db.Cntrlogitem.Remove(cntrlogitem);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
