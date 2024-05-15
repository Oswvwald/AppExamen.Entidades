using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppExamen.Entidades;

namespace AppExamen.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmacosController : ControllerBase
    {
        private readonly DbContext _context;

        public FarmacosController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Farmacos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Farmaco>>> GetFarmacos()
        {
            return await _context.Set<Farmaco>()
                .Include(f => f.Marca)
                .ToListAsync();
        }

        // GET: api/Farmacos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Farmaco>> GetFarmaco(int id)
        {
            var farmaco = await _context.Set<Farmaco>()
                .Include(f => f.Marca)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (farmaco == null)
            {
                return NotFound();
            }

            return farmaco;
        }

        // PUT: api/Farmacos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFarmaco(int id, Farmaco farmaco)
        {
            if (id != farmaco.Id)
            {
                return BadRequest();
            }

            _context.Entry(farmaco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FarmacoExists(id))
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

        // POST: api/Farmacos
        [HttpPost]
        public async Task<ActionResult<Farmaco>> PostFarmaco(Farmaco farmaco)
        {
            _context.Set<Farmaco>().Add(farmaco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFarmaco), new { id = farmaco.Id }, farmaco);
        }

        // DELETE: api/Farmacos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFarmaco(int id)
        {
            var farmaco = await _context.Set<Farmaco>().FindAsync(id);
            if (farmaco == null)
            {
                return NotFound();
            }

            _context.Set<Farmaco>().Remove(farmaco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FarmacoExists(int id)
        {
            return _context.Set<Farmaco>().Any(e => e.Id == id);
        }
    }
}
