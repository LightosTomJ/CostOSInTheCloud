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
  public class EquipmentsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Equipment> lEquipments = db.Equipment.GetAllCompanyEquipments(id);
          //return JsonConvert.SerializeObject(lEquipments.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Equipment equipment)
      {
          //Create
          db.Equipment.Add(equipment);
          db.SaveChanges();
          return JsonConvert.SerializeObject(equipment);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Equipment equipment)
      {
          //Update
          db.Equipment.Update(equipment);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Equipment equipment)
      {
          db.Equipment.Remove(equipment);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
