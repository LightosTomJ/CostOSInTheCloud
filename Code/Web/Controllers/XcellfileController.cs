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
  public class XcellfilesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Xcellfile> lXcellfiles = db.Xcellfile.GetAllCompanyXcellfiles(id);
          //return JsonConvert.SerializeObject(lXcellfiles.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Xcellfile xcellfile)
      {
          //Create
          db.Xcellfile.Add(xcellfile);
          db.SaveChanges();
          return JsonConvert.SerializeObject(xcellfile);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Xcellfile xcellfile)
      {
          //Update
          db.Xcellfile.Update(xcellfile);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Xcellfile xcellfile)
      {
          db.Xcellfile.Remove(xcellfile);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
