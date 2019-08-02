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
  public class FiltrosController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Filtro> lFiltros = db.Filtro.GetAllCompanyFiltros(id);
          //return JsonConvert.SerializeObject(lFiltros.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Filtro filtro)
      {
          //Create
          db.Filtro.Add(filtro);
          db.SaveChanges();
          return JsonConvert.SerializeObject(filtro);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Filtro filtro)
      {
          //Update
          db.Filtro.Update(filtro);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Filtro filtro)
      {
          db.Filtro.Remove(filtro);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
