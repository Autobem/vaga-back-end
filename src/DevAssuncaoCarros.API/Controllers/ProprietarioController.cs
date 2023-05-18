using AutoMapper;
using DevAssuncaoCarros.API.ViewModels;
using DevAssuncaoCarros.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DevAssuncaoCarros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietarioController : ControllerBase
    {
        private readonly IProprietarioRepository _proprietarioRepository;
        private readonly IMapper _mapper;

        public ProprietarioController(IProprietarioRepository proprietarioRepository, IMapper mapper)
        {
            _proprietarioRepository = proprietarioRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProprietarioViewModel>>>  GetAllProprietarios()
        {
            var todosProprietarios = _mapper.Map<IEnumerable<ProprietarioViewModel>>(_proprietarioRepository.ObterTodos());
            return Ok(todosProprietarios);
        }
    }
}
