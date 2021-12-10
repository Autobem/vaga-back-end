using VeiculosApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBeckEnd_EvertonLeao.Data;
using TesteBeckEnd_EvertonLeao.Data.Dtos;
using AutoMapper;

namespace VeiculosApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VeiculosController : ControllerBase
    {
        private VeiculoContext _context;
        private IMapper _mapper;

        public VeiculosController(VeiculoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaVeiculo([FromBody] CreateVeiculoDto veiculoDto)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(veiculoDto);
   

            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaVeiculosPorId), new { Id = veiculo.Id }, veiculo);

        }

        [HttpGet]
        public IEnumerable<Veiculo> RecuperarVeiculos()
        {
            return (_context.Veiculos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaVeiculosPorId(int id)
        {
           Veiculo veiculo = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
            if (veiculo != null)
            {
                ReadVeiculoDto veiculoDto = _mapper.Map<ReadVeiculoDto>(veiculo);
                return Ok(veiculo);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaVeiculo(int id, [FromBody] UpdateVeiculoDto veiculoDto)
        {
            Veiculo veiculo = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _mapper.Map(veiculoDto, veiculo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaVeiculo(int id)
        {
            Veiculo veiculo = _context.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
            if (veiculo == null)
            {
                return NotFound();
            }
            _context.Remove(veiculo);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
