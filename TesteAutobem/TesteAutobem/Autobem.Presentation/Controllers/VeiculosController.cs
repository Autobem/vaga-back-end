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
    public class VeiculosController : ControllerBase
    {
        private readonly IVeiculoServiceApp _service;
        private readonly IMapper _mapper;

        public CoresController(IVeiculoServiceApp service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("ListarTodos")]
        public IEnumerable<VeiculoDTO> List()
        {
            IEnumerable<Veiculo> veiculo = _service.GetAll();
            IEnumerable<VeiculoDTO> veiculoDTO = _mapper.Map<IEnumerable<VeiculoDTO>>(veiculo);

            return veiculoDTO;
        }

        [HttpGet]
        [Route("Listar/{id}")]
        public VeiculoDTO List(int id)
        {
            Veiculo veiculo = _service.GetById(id);
            VeiculoDTO veiculoDTO = _mapper.Map<VeiculoDTO>(veiculo);

            return veiculoDTO;
        }

        [HttpPost]
        [Route("Adicionar")]
        public ActionResult Add(VeiculoDTO veiculoDTO)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(VeiculoDTO);
            _service.Add(proprietario);

            return Ok(veiculo);
        }

        [HttpPost]
        [Route("Editar/{id}")]
        public ActionResult Update(VeiculoDTO veiculoDTO)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(veiculoDTO);
            _service.Update(proprietario);

            return Ok(veiculo);
        }

        [HttpDelete]
        [Route("Excluir/{id}")]
        public ActionResult Remove(VeiculoDTO veiculoDTO)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(veiculoDTO);
            _service.Remove(veiculo);

            return Ok(veiculo);
        }
    }
}
