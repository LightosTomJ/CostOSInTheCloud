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
  public class QueryresourcesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Queryresource> lQueryresources = db.Queryresource.GetAllCompanyQueryresources(id);
          //return JsonConvert.SerializeObject(lQueryresources.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Queryresource queryresource)
      {
          //Create
          db.Queryresource.Add(queryresource);
          db.SaveChanges();
          return JsonConvert.SerializeObject(queryresource);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Queryresource queryresource)
      {
          //Update
          db.Queryresource.Update(queryresource);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Queryresource queryresource)
      {
          db.Queryresource.Remove(queryresource);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
