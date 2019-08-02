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
  public class AssemblyChildsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AssemblyChild> lAssemblyChilds = db.AssemblyChild.GetAllCompanyAssemblyChilds(id);
          //return JsonConvert.SerializeObject(lAssemblyChilds.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AssemblyChild assemblychild)
      {
          //Create
          db.AssemblyChild.Add(assemblychild);
          db.SaveChanges();
          return JsonConvert.SerializeObject(assemblychild);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AssemblyChild assemblychild)
      {
          //Update
          db.AssemblyChild.Update(assemblychild);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AssemblyChild assemblychild)
      {
          db.AssemblyChild.Remove(assemblychild);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
