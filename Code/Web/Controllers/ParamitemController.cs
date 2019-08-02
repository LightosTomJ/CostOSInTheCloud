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
  public class ParamitemsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Paramitem> lParamitems = db.Paramitem.GetAllCompanyParamitems(id);
          //return JsonConvert.SerializeObject(lParamitems.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Paramitem paramitem)
      {
          //Create
          db.Paramitem.Add(paramitem);
          db.SaveChanges();
          return JsonConvert.SerializeObject(paramitem);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Paramitem paramitem)
      {
          //Update
          db.Paramitem.Update(paramitem);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Paramitem paramitem)
      {
          db.Paramitem.Remove(paramitem);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
