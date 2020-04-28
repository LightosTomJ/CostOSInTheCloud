using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Config;

namespace API.Controllers.DB.Config
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ConfigContext _context;

        public CompaniesController(ConfigContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<IEnumerable<Companies>> GetCompanies()
        {
            return await _context.Companies.ToListAsync();
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<Companies> GetCompanyById(int id)
        {
            var companies = await _context.Companies.FindAsync(id);

            if (companies == null) return null;

            return companies;
        }

        // PUT: api/Companies/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanies(int id, Companies companies)
        {
            if (id != companies.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(companies).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompaniesExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Companies
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Companies>> PostCompanies(Companies companies)
        {
            _context.Companies.Add(companies);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanies", new { id = companies.CompanyId }, companies);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Companies>> DeleteCompanies(int id)
        {
            var companies = await _context.Companies.FindAsync(id);
            if (companies == null)
            {
                return NotFound();
            }

            _context.Companies.Remove(companies);
            await _context.SaveChangesAsync();

            return companies;
        }

        private bool CompaniesExists(int id)
        {
            return _context.Companies.Any(e => e.CompanyId == id);
        }
    }
}
