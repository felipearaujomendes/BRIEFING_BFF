using AutoMapper;
using Briefing.Application.Commands;
using Briefing.Application.Queries;
using Briefing.Application.ViewModels;
using Briefing.Domain.Interfaces.Mediatrs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Briefing.WebApps.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespostaController : ControllerBase
    {

        private readonly IMediatrHandler _mediatr;
        private readonly IMapper _mapper;
        private readonly IRespostaQueries _respostaQueries;
        public RespostaController(IMediatrHandler mediatr, IMapper mapper, IRespostaQueries respostaQueries)
        {
            _mediatr = mediatr;
            _mapper = mapper;
            _respostaQueries = respostaQueries;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarRespostaViewModel adicionarRespostaView)
        {
            var command = _mapper.Map<AdicionarRespostaCommand>(adicionarRespostaView);
            var sucesso = await _mediatr.EnviarComando(command);

            if (!sucesso) return BadRequest();

            return CreatedAtAction(nameof(ObterPorId), new { Id = command.AggregateRoot }, new { Id = command.AggregateRoot, Display = command.Valor });

        }
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var respostas = await _respostaQueries.ObterTodos();
            return Ok(respostas);
        }
        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var resposta = await _respostaQueries.ObterPorId(id);
            return Ok(resposta);
        }
    }
}
