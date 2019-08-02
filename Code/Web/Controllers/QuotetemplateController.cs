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
  public class QuotetemplatesController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Quotetemplate> lQuotetemplates = db.Quotetemplate.GetAllCompanyQuotetemplates(id);
          //return JsonConvert.SerializeObject(lQuotetemplates.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Quotetemplate quotetemplate)
      {
          //Create
          db.Quotetemplate.Add(quotetemplate);
          db.SaveChanges();
          return JsonConvert.SerializeObject(quotetemplate);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Quotetemplate quotetemplate)
      {
          //Update
          db.Quotetemplate.Update(quotetemplate);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Quotetemplate quotetemplate)
      {
          db.Quotetemplate.Remove(quotetemplate);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
