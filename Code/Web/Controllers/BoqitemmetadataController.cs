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
  public class BoqitemmetadatasController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Boqitemmetadata> lBoqitemmetadatas = db.Boqitemmetadata.GetAllCompanyBoqitemmetadatas(id);
          //return JsonConvert.SerializeObject(lBoqitemmetadatas.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Boqitemmetadata boqitemmetadata)
      {
          //Create
          db.Boqitemmetadata.Add(boqitemmetadata);
          db.SaveChanges();
          return JsonConvert.SerializeObject(boqitemmetadata);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Boqitemmetadata boqitemmetadata)
      {
          //Update
          db.Boqitemmetadata.Update(boqitemmetadata);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Boqitemmetadata boqitemmetadata)
      {
          db.Boqitemmetadata.Remove(boqitemmetadata);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
