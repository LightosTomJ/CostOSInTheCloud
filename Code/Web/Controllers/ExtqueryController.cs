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
  public class ExtquerysController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Extquery> lExtquerys = db.Extquery.GetAllCompanyExtquerys(id);
          //return JsonConvert.SerializeObject(lExtquerys.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Extquery extquery)
      {
          //Create
          db.Extquery.Add(extquery);
          db.SaveChanges();
          return JsonConvert.SerializeObject(extquery);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Extquery extquery)
      {
          //Update
          db.Extquery.Update(extquery);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Extquery extquery)
      {
          db.Extquery.Remove(extquery);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
