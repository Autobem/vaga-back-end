using AutoMapper;
using DevAssuncaoCarros.API.ViewModels;
using DevAssuncaoCarros.Business.Interfaces;
using DevAssuncaoCarros.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevAssuncaoCarros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarroController : ControllerBase
    {
        private readonly ICarroRepository _carroRepository;
        private readonly IMapper _mapper;
        private readonly ICarroService _carroService;

        public CarroController(ICarroRepository carroRepository, IMapper mapper, ICarroService carroService)
        {
            _carroRepository = carroRepository;
            _carroService = carroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarroViewModel>>> GetAllCarros()
        {
            var todosCarros = _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterTodos());
            return Ok(todosCarros);
        }

        [HttpGet("carros-por-id/{id:guid}")]
        public async Task<ActionResult<IEnumerable<CarroViewModel>>> GetCarroId(Guid id)
        {
            var carro = await _carroRepository.ObterPorId(id);

            if (carro is null)
            {
                return BadRequest("Carro nao encontrado");
            }
            return Ok(carro);
        }

        [HttpGet("carro-por-proprietario/{id:guid}")]
        public async Task<ActionResult<IEnumerable<CarroViewModel>>> GetCarroProprietario(Guid id)
        {
            var carro = await GetObterCarrosPorProprietarios(id);
            return Ok(carro);
        }

        [HttpPost]
        public async Task<ActionResult<CarroViewModel>> CriaCarro(CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            await _carroService.AddCarro(_mapper.Map<Carro>(carroViewModel));

            return Ok(carroViewModel);
        }


        [HttpPut]
        public async Task<ActionResult<CarroViewModel>> AtualizarCarro(Guid id, CarroViewModel carroView)
        {
            if (id != carroView.Id)
            {
                return BadRequest("Carro não relacionado com  id passado pelo request");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.Values);
            }

            await _carroService.AtualizarCarro(_mapper.Map<Carro>(carroView));

            return Ok(carroView);
        }


        [HttpDelete]
        public async Task<ActionResult<CarroViewModel>> RemoverCarro(Guid id)
        {

            var hasCarro = await ObterCarroPorId(id);

            if (hasCarro is null)
            {
                return BadRequest("Carro nao encontrado");
            }

            await _carroService.RemoverCarro(id);

            return Ok(hasCarro);
        }

        private async Task<IEnumerable<CarroViewModel>> GetObterCarrosPorProprietarios(Guid id)
        {
            var proprietariosCarros = _mapper.Map<IEnumerable<CarroViewModel>>(await _carroRepository.ObterCarrosProprietario(id));
            return proprietariosCarros;
        }

        private async Task<CarroViewModel> ObterCarroPorId (Guid id)
        {
            return _mapper.Map<CarroViewModel>(await _carroRepository.ObterPorId(id));
        }
    }
}
