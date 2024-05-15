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
    public class MarcaFarmaceuticasController : ControllerBase
    {
        private readonly DbContext _context;

        public MarcaFarmaceuticasController(DbContext context)
        {
            _context = context;
        }

        // GET: api/MarcaFarmaceuticas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaFarmaceutica>>> GetMarcaFarmaceuticas()
        {
            return await _context.MarcaFarmaceutica.ToListAsync();
        }

        // GET: api/MarcaFarmaceuticas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MarcaFarmaceutica>> GetMarcaFarmaceutica(int id)
        {
            var marcaFarmaceutica = await _context.MarcaFarmaceutica.FindAsync(id);

            if (marcaFarmaceutica == null)
            {
                return NotFound();
            }

            return marcaFarmaceutica;
        }

        // PUT: api/MarcaFarmaceuticas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMarcaFarmaceutica(int id, MarcaFarmaceutica marcaFarmaceutica)
        {
            if (id != marcaFarmaceutica.Id)
            {
                return BadRequest();
            }

            _context.Entry(marcaFarmaceutica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaFarmaceuticaExists(id))
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

        // POST: api/MarcaFarmaceuticas
        [HttpPost]
        public async Task<ActionResult<MarcaFarmaceutica>> PostMarcaFarmaceutica(MarcaFarmaceutica marcaFarmaceutica)
        {
            _context.MarcaFarmaceutica.Add(marcaFarmaceutica);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMarcaFarmaceutica", new { id = marcaFarmaceutica.Id }, marcaFarmaceutica);
        }

        // DELETE: api/MarcaFarmaceuticas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMarcaFarmaceutica(int id)
        {
            var marcaFarmaceutica = await _context.MarcaFarmaceutica.FindAsync(id);
            if (marcaFarmaceutica == null)
            {
                return NotFound();
            }

            _context.MarcaFarmaceutica.Remove(marcaFarmaceutica);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MarcaFarmaceuticaExists(int id)
        {
            return _context.MarcaFarmaceutica.Any(e => e.Id == id);
        }
    }
}
