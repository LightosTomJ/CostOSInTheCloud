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
  public class FiltropropertysController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Filtroproperty> lFiltropropertys = db.Filtroproperty.GetAllCompanyFiltropropertys(id);
          //return JsonConvert.SerializeObject(lFiltropropertys.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Filtroproperty filtroproperty)
      {
          //Create
          db.Filtroproperty.Add(filtroproperty);
          db.SaveChanges();
          return JsonConvert.SerializeObject(filtroproperty);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Filtroproperty filtroproperty)
      {
          //Update
          db.Filtroproperty.Update(filtroproperty);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Filtroproperty filtroproperty)
      {
          db.Filtroproperty.Remove(filtroproperty);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
