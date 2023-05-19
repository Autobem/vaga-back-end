using AutoMapper;
using DevAssuncaoCarros.API.ViewModels;
using DevAssuncaoCarros.Business.Interfaces;
using DevAssuncaoCarros.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevAssuncaoCarros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IMapper _mapper;
        private readonly IProprietarioService _proprietarioService;
        private readonly IEnderecoRepository _enderecoRepository;


        public ProprietarioController(IProprietarioRepository proprietarioRepository, IMapper mapper, IProprietarioService proprietarioService, IEnderecoRepository endereco)
        {
            _proprietarioRepository = proprietarioRepository;
            _mapper = mapper;
            _proprietarioService = proprietarioService;
            _enderecoRepository = endereco;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProprietarioViewModel>>> GetAllProprietarios()
        {
            var todosProprietarios = _mapper.Map<IEnumerable<ProprietarioViewModel>>(await _proprietarioRepository.ObterTodos());
            return Ok(todosProprietarios);
        }

        [HttpGet("carros-por-proprietarios/{id:guid}")]
        public async Task<ActionResult<IEnumerable<ProprietarioViewModel>>> GetCarrosPorProprietarios(Guid id)
        {
            var proprietarioCarros = await GetObterCarroPorProprietarios(id);
            return Ok(proprietarioCarros);
        }

        [HttpGet("endereco/{id:guid}")]
        public async Task<ActionResult<IEnumerable<ProprietarioViewModel>>> GetEnderecoProprietario(Guid id)
        {
            var proprietarioEnde = await GetEnderecoPorProprietario(id);
            return Ok(proprietarioEnde);
        }

        [HttpPost]
        public async Task<ActionResult<ProprietarioViewModel>> CriaProprietario(ProprietarioViewModel proprietario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            await _proprietarioService.AddProprietario(_mapper.Map<Proprietario>(proprietario));

            return Ok(proprietario);
        }


        [HttpPut]
        public async Task<ActionResult<ProprietarioViewModel>> AtualizarProprietario(Guid id, ProprietarioViewModel proprietario)
        {
            if (id != proprietario.Id)
            {
                return BadRequest("Proprietario não relacionado com  id passado pelo request");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            await _proprietarioService.AtualizarProprietario(_mapper.Map<Proprietario>(proprietario));

            return Ok(proprietario);
        }


        [HttpDelete]
        public async Task<ActionResult<ProprietarioViewModel>> RemoverProprietario(Guid id)
        {

            var hasProprietario = await _proprietarioRepository.ObterPorId(id);

            if (hasProprietario is null)
            {
                return BadRequest("Proprietario nao encontrado");
            }

            await _proprietarioService.RemoveProprietario(id);

            return Ok(hasProprietario);
        }

        [HttpGet("atualizar-endereco-prop/{id:guid}")]
        public async Task<ActionResult<EnderecoViewModel>> AtualizarEnderecoProp (EnderecoViewModel endereco, Guid id)
        {
            if (id != endereco.ProprietarioId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _enderecoRepository.Atualizar(_mapper.Map<Endereco>(endereco));

            return Ok(endereco);
        }



        private async Task<IEnumerable<ProprietarioViewModel>> GetObterCarroPorProprietarios(Guid id)
        {
            var proprietariosCarros = _mapper.Map<IEnumerable<ProprietarioViewModel>>(await _proprietarioRepository.ObterCarrosPorProprietarios(id));
            return proprietariosCarros;
        }

        private async Task<ProprietarioViewModel> GetEnderecoPorProprietario(Guid id)
        {
            var proprietarioEndereco = _mapper.Map<ProprietarioViewModel>(await _proprietarioRepository.ObterProprietarioEndereco(id));
            return proprietarioEndereco;
        }
    }
}
