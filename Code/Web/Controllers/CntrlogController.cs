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
  public class CntrlogsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Cntrlog> lCntrlogs = db.Cntrlog.GetAllCompanyCntrlogs(id);
          //return JsonConvert.SerializeObject(lCntrlogs.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Cntrlog cntrlog)
      {
          //Create
          db.Cntrlog.Add(cntrlog);
          db.SaveChanges();
          return JsonConvert.SerializeObject(cntrlog);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Cntrlog cntrlog)
      {
          //Update
          db.Cntrlog.Update(cntrlog);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Cntrlog cntrlog)
      {
          db.Cntrlog.Remove(cntrlog);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
