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
  public class LayoutcpanelsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Layoutcpanel> lLayoutcpanels = db.Layoutcpanel.GetAllCompanyLayoutcpanels(id);
          //return JsonConvert.SerializeObject(lLayoutcpanels.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Layoutcpanel layoutcpanel)
      {
          //Create
          db.Layoutcpanel.Add(layoutcpanel);
          db.SaveChanges();
          return JsonConvert.SerializeObject(layoutcpanel);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Layoutcpanel layoutcpanel)
      {
          //Update
          db.Layoutcpanel.Update(layoutcpanel);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Layoutcpanel layoutcpanel)
      {
          db.Layoutcpanel.Remove(layoutcpanel);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
