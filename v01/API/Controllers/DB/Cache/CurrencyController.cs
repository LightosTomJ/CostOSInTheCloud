using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.DB.Cache;

namespace API.Controllers.DB.Cache
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly cacheContext _context;

        public CurrencyController(cacheContext context)
        {
            _context = context;
        }

        // GET: api/Currency
        [HttpGet]
        public async Task<List<Currency>> GetCurrencies()
        {
            return await _context.Currency.ToListAsync();
        }

        // GET: api/Currency/5
        [HttpGet("{id}")]
        public async Task<Currency> GetCurrency(short id)
        {
            var currency = await _context.Currency.FindAsync(id);

            if (currency == null)
            {
                return null;
            }

            return currency;
        }

        // PUT: api/Currency/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurrency(short id, Currency currency)
        {
            if (id != currency.CurrencyId)
            {
                return BadRequest();
            }

            _context.Entry(currency).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        // POST: api/Currency
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<Currency> PostCurrency(Currency currency)
        {
            _context.Currency.Add(currency);
            await _context.SaveChangesAsync();

            return currency;
        }

        // DELETE: api/Currency/5
        [HttpDelete("{id}")]
        public async Task<Currency> DeleteCurrency(short id)
        {
            var currency = await _context.Currency.FindAsync(id);
            if (currency == null)
            {
                return null;
            }

            _context.Currency.Remove(currency);
            await _context.SaveChangesAsync();

            return currency;
        }

        private bool CurrencyExists(short id)
        {
            return _context.Currency.Any(e => e.CurrencyId == id);
        }
    }
}
