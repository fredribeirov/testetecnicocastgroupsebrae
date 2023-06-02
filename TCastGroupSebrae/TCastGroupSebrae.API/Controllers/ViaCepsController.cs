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
    public class ViaCepsController : ControllerBase
    {
        readonly IViaCepService _viaCepService;
        public ViaCepsController(IViaCepService viaCepService)
        {
            _viaCepService = viaCepService;
        }

     

        // GET: api/ViaCeps/39390000
        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCep>> GetViaCep(string cep)
        {
          if (_viaCepService == null)
          {
              return NotFound();
          }
            var viaCep = await _viaCepService.BuscaCep(cep);

            if (viaCep == null)
            {
                return NotFound();
            }

            return Ok(viaCep);
        }

    }
}
