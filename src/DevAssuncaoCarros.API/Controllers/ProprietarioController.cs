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


        public ProprietarioController(IProprietarioRepository proprietarioRepository, IMapper mapper, IProprietarioService proprietarioService)
        {
            _proprietarioRepository = proprietarioRepository;
            _mapper = mapper;
            _proprietarioService = proprietarioService;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProprietarioViewModel>>>  GetAllProprietarios()
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
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            await _proprietarioService.AddProprietario(_mapper.Map<Proprietario>(proprietario));

            return Ok(proprietario);

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
