using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChatBot.Data;
using ChatBot.Model;

namespace ChatBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtapasController : ControllerBase
    {
        private readonly ChatBotContext _context;

        public EtapasController(ChatBotContext context)
        {
            _context = context;
        }

        // GET: api/Etapas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Etapa>>> GetEtapa()
        {
            return await _context.Etapa.ToListAsync();
        }

        // GET: api/Etapas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Etapa>> GetEtapa(int id)
        {
            var etapa = await _context.Etapa.FindAsync(id);

            if (etapa == null)
            {
                return NotFound();
            }

            return etapa;
        }

        // PUT: api/Etapas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEtapa(int id, Etapa etapa)
        {
            if (id != etapa.Id)
            {
                return BadRequest();
            }

            _context.Entry(etapa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EtapaExists(id))
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

        // POST: api/Etapas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Etapa>> PostEtapa(Etapa etapa)
        {
            _context.Etapa.Add(etapa);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEtapa", new { id = etapa.Id }, etapa);
        }

        // DELETE: api/Etapas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Etapa>> DeleteEtapa(int id)
        {
            var etapa = await _context.Etapa.FindAsync(id);
            if (etapa == null)
            {
                return NotFound();
            }

            _context.Etapa.Remove(etapa);
            await _context.SaveChangesAsync();

            return etapa;
        }

        private bool EtapaExists(int id)
        {
            return _context.Etapa.Any(e => e.Id == id);
        }
    }
}
