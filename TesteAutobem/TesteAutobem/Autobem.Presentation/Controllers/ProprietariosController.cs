using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autobem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietariosController : ControllerBase
    {
        private readonly IProprietarioServiceApp _service;
        private readonly IMapper _mapper;

        public CoresController(IProprietarioServiceApp service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public IEnumerable<ProprietarioDTO> List()
        {
            IEnumerable<Proprietario> proprietarios = _service.GetAll();
            IEnumerable<ProprietarioDTO> proprietarioDTO = _mapper.Map<IEnumerable<ProprietarioDTO>>(proprietario);

            return proprietarioDTO;
        }

        [HttpGet]
        [Route("Listar/{id}")]
        public ProprietarioDTO List(int id)
        {
            Proprietario proprietario = _service.GetById(id);
            ProprietarioDTO proprietarioDTO = _mapper.Map<proprietarioDTO>(proprietario);

            return proprietarioDTO;
        }

        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Add(ProprietarioDTO proprietarioDTO)
        {
            Proprietario proprietario = _mapper.Map<Proprietario>(proprietarioDTO);
            _service.Add(proprietario);

            return Ok(proprietario);
        }

        [HttpPost]
        [Route("Editar/{id}")]
        public ActionResult Update(ProprietarioDTO proprietarioDTO)
        {
            Proprietario proprietario = _mapper.Map<Proprietario>(proprietarioDTO);
            _service.Update(proprietario);

            return Ok(proprietario);
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public ActionResult Remove(ProprietarioDTO proprietarioDTO)
        {
            Proprietario proprietario = _mapper.Map<Proprietario>(proprietarioDTO);
            _service.Remove(proprietario);

            return Ok(proprietario);
        }
    }
}

