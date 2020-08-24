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
    public class RespostasController : ControllerBase
    {
        private readonly ChatBotContext _context;

        public RespostasController(ChatBotContext context)
        {
            _context = context;
        }

        // GET: api/Respostas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resposta>>> GetResposta()
        {
            return await _context.Resposta.ToListAsync();
        }

        // GET: api/Respostas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resposta>> GetResposta(int id)
        {
            var resposta = await _context.Resposta.FindAsync(id);

            if (resposta == null)
            {
                return NotFound();
            }

            return resposta;
        }

        // PUT: api/Respostas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResposta(int id, Resposta resposta)
        {
            if (id != resposta.Id)
            {
                return BadRequest();
            }

            _context.Entry(resposta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespostaExists(id))
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

        // POST: api/Respostas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Resposta>> PostResposta(Resposta resposta)
        {
            _context.Resposta.Add(resposta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResposta", new { id = resposta.Id }, resposta);
        }

        // DELETE: api/Respostas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Resposta>> DeleteResposta(int id)
        {
            var resposta = await _context.Resposta.FindAsync(id);
            if (resposta == null)
            {
                return NotFound();
            }

            _context.Resposta.Remove(resposta);
            await _context.SaveChangesAsync();

            return resposta;
        }

        private bool RespostaExists(int id)
        {
            return _context.Resposta.Any(e => e.Id == id);
        }
    }
}
