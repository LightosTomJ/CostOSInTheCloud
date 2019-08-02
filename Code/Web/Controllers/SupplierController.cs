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
  public class SuppliersController : Controller
  {
      private Costos2019Context db = new Costos2019Context();
      // GET api/values/5
      [HttpGet("{id}")]
      public string Get(int id)
      {
          //List<Supplier> lSuppliers = db.Supplier.GetAllCompanySuppliers(id);
          //return JsonConvert.SerializeObject(lSuppliers.ToArray());
          return "";
      }

      // POST api/values
      [HttpPost]
      public string Post([FromBody]Supplier supplier)
      {
          //Create
          db.Supplier.Add(supplier);
          db.SaveChanges();
          return JsonConvert.SerializeObject(supplier);
      }

      // PUT api/values/5
      [HttpPut("{id}")]
      public void Put(int id, [FromBody]Supplier supplier)
      {
          //Update
          db.Supplier.Update(supplier);
          db.SaveChanges();
      }

      // DELETE api/values/5
      [HttpDelete("{id}")]
      public string Delete([FromBody]Supplier supplier)
      {
          db.Supplier.Remove(supplier);
          db.SaveChanges();
          return JsonConvert.SerializeObject("Ok");
      }
  }
}
