using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TCastGroupSebrae.API.Interface;
using TCastGroupSebrae.API.Model;

namespace TCastGroupSebrae.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private IContaRepositorio _contaRepositorio;

        public ContasController(IContaRepositorio contaRepositorio)
        {
            _contaRepositorio = contaRepositorio;
        }

       

        // GET: api/Contas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Conta>> GetConta(int id)
        {
          if (_contaRepositorio == null)
          {
              return NotFound();
          }
            var conta = await   _contaRepositorio.BuscaPorId(id);

            if (conta == null)
            {
                return NotFound();
            }

            return Ok(conta);
        }

        // PUT: api/Contas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConta(int id, Conta conta)
        {
            if (id != conta.Id)
            {
                return BadRequest();
            }
            try
            {
                _contaRepositorio.Atualizar(conta);
            }
            catch (Exception ex)
            {
                return BadRequest();
                throw;
                
            }

            return NoContent();
        }

        // POST: api/Contas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Conta>> PostConta(Conta conta)
        {
          if (_contaRepositorio == null)
          {
              return Problem("Respositorio não pode ser nulo.");
          }
            _contaRepositorio.Inserir(conta);

            return CreatedAtAction("GetConta", new { id = conta.Id }, conta);
        }

        // DELETE: api/Contas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConta(int id)
        {
            
            var deletado = await _contaRepositorio.Excluir(id);           
            return NoContent();
           
 
        }

        
    }
}
