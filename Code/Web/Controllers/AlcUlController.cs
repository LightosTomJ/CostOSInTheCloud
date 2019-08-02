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
  public class AlcUlsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AlcUl> lAlcUls = db.AlcUl.GetAllCompanyAlcUls(id);
          //return JsonConvert.SerializeObject(lAlcUls.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AlcUl alcul)
      {
          //Create
          db.AlcUl.Add(alcul);
          db.SaveChanges();
          return JsonConvert.SerializeObject(alcul);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AlcUl alcul)
      {
          //Update
          db.AlcUl.Update(alcul);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AlcUl alcul)
      {
          db.AlcUl.Remove(alcul);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
