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
    public class PerguntaController : ControllerBase
    {
        private readonly IMediatrHandler _mediatr;
        private readonly IMapper _mapper;
        private readonly IPerguntaQueries _perguntaQueries;
        public PerguntaController(IMediatrHandler mediatr, IMapper mapper, IPerguntaQueries perguntaQueries)
        {
            _mediatr = mediatr;
            _mapper = mapper;
            _perguntaQueries = perguntaQueries;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AdicionarPerguntaViewModel perguntaViewModel)
        {
            var command = _mapper.Map<AdicionarPerguntaCommand>(perguntaViewModel);
            var sucesso = await _mediatr.EnviarComando(command);

            if (!sucesso) return BadRequest();

            return CreatedAtAction(nameof(ObterPorId), new { Id = command.AggregateRoot }, new { Id = command.AggregateRoot, Display = command.Display });
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var perguntas = await _perguntaQueries.ObterTodos();
            return Ok(perguntas);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            var pergunta = await _perguntaQueries.ObterPorId(id);
            return Ok(pergunta);
        }
    }
}
