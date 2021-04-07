using Autobem.Application;
using Autobem.Application.DTO;
using Autobem.Application.Interfaces;
using Autobem.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Autobem.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoresController : Controller
    {
        private readonly ICorServiceApp _service;
        private readonly IMapper _mapper;

        public CoresController(ICorServiceApp service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public IEnumerable<CorDTO> List()
        {
            IEnumerable<Cor> cores = _service.GetAll();
            IEnumerable<CorDTO> coresDTO = _mapper.Map<IEnumerable<CorDTO>>(cores);

            return coresDTO;
        }

        [HttpGet]
        [Route("Listar/{id}")]
        public CorDTO List(int id)
        {
            Cor cor = _service.GetById(id);
            CorDTO corDTO = _mapper.Map<CorDTO>(cor);

            return corDTO;
        }

        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Add(CorDTO corDTO)
        {
            Cor cor = _mapper.Map<Cor>(corDTO);
            _service.Add(cor);

            return Ok(cor);
        }

        [HttpPost]
        [Route("Editar/{id}")]
        public ActionResult Update(CorDTO corDTO)
        {
            Cor cor = _mapper.Map<Cor>(corDTO);
            _service.Update(cor);

            return Ok(cor);
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public ActionResult Remove(CorDTO corDTO)
        {
            Cor cor = _mapper.Map<Cor>(corDTO);
            _service.Remove(cor);

            return Ok(cor);
        }
    }
}
