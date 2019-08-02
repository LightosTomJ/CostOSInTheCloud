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
  public class AssemblyEquipmentsController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<AssemblyEquipment> lAssemblyEquipments = db.AssemblyEquipment.GetAllCompanyAssemblyEquipments(id);
          //return JsonConvert.SerializeObject(lAssemblyEquipments.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]AssemblyEquipment assemblyequipment)
      {
          //Create
          db.AssemblyEquipment.Add(assemblyequipment);
          db.SaveChanges();
          return JsonConvert.SerializeObject(assemblyequipment);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]AssemblyEquipment assemblyequipment)
      {
          //Update
          db.AssemblyEquipment.Update(assemblyequipment);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]AssemblyEquipment assemblyequipment)
      {
          db.AssemblyEquipment.Remove(assemblyequipment);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
