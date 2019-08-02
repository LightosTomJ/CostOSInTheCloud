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
  public class BenchmarkboqcolmapsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Benchmarkboqcolmap> lBenchmarkboqcolmaps = db.Benchmarkboqcolmap.GetAllCompanyBenchmarkboqcolmaps(id);
          //return JsonConvert.SerializeObject(lBenchmarkboqcolmaps.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Benchmarkboqcolmap benchmarkboqcolmap)
      {
          //Create
          db.Benchmarkboqcolmap.Add(benchmarkboqcolmap);
          db.SaveChanges();
          return JsonConvert.SerializeObject(benchmarkboqcolmap);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Benchmarkboqcolmap benchmarkboqcolmap)
      {
          //Update
          db.Benchmarkboqcolmap.Update(benchmarkboqcolmap);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Benchmarkboqcolmap benchmarkboqcolmap)
      {
          db.Benchmarkboqcolmap.Remove(benchmarkboqcolmap);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
