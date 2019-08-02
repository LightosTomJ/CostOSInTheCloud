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
  public class QueryrowsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Queryrow> lQueryrows = db.Queryrow.GetAllCompanyQueryrows(id);
          //return JsonConvert.SerializeObject(lQueryrows.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Queryrow queryrow)
      {
          //Create
          db.Queryrow.Add(queryrow);
          db.SaveChanges();
          return JsonConvert.SerializeObject(queryrow);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Queryrow queryrow)
      {
          //Update
          db.Queryrow.Update(queryrow);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Queryrow queryrow)
      {
          db.Queryrow.Remove(queryrow);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
