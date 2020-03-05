using System;
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
    public class ExchangeRateController : ControllerBase
    {
        private readonly cacheContext _context;

        public ExchangeRateController(cacheContext context)
        {
            _context = context;
        }

        // GET: api/ExchangeRate
        [HttpGet]
        public async Task<List<ExchangeRate>> AllExchangeRates()
        {
            return await _context.ExchangeRate.ToListAsync();
        }

        // GET: api/ExchangeRate/5
        [HttpGet("{id}")]
        public async Task<ExchangeRate> GetExchangeRate(Guid id)
        {
            var exchangeRate = await _context.ExchangeRate.FindAsync(id);

            if (exchangeRate == null)
            {
                return null;
            }

            return exchangeRate;
        }

        // PUT: api/ExchangeRate/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExchangeRate(Guid id, ExchangeRate exchangeRate)
        {
            if (id != exchangeRate.ExchangeRateId)
            {
                return BadRequest();
            }

            _context.Entry(exchangeRate).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExchangeRateExists(id))
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

        // POST: api/ExchangeRate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ExchangeRate> PostExchangeRate(ExchangeRate exchangeRate)
        {
            _context.ExchangeRate.Add(exchangeRate);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ExchangeRateExists(exchangeRate.ExchangeRateId))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return exchangeRate;
        }

        // DELETE: api/ExchangeRate/5
        [HttpDelete("{id}")]
        public async Task<ExchangeRate> DeleteExchangeRate(Guid id)
        {
            var exchangeRate = await _context.ExchangeRate.FindAsync(id);
            if (exchangeRate == null)
            {
                return null;
            }

            _context.ExchangeRate.Remove(exchangeRate);
            await _context.SaveChangesAsync();

            return exchangeRate;
        }

        private bool ExchangeRateExists(Guid id)
        {
            return _context.ExchangeRate.Any(e => e.ExchangeRateId == id);
        }
    }
}
