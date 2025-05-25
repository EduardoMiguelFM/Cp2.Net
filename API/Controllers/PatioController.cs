namespace Mottu.API.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Mottu.Application.DTOs;
    using Mottu.Application.Interfaces;

    [ApiController]
    [Route("api/[controller]")]
    public class PatioController : ControllerBase
    {
        private readonly IPatioService _patioService;

        public PatioController(IPatioService patioService)
        {
            _patioService = patioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _patioService.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) => Ok(await _patioService.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PatioDTO dto)
        {
            var result = await _patioService.CreateAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PatioDTO dto) => Ok(await _patioService.UpdateAsync(id, dto));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _patioService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("setor/{setor}/contagem")]
        public async Task<IActionResult> ContagemPorSetor(string setor) => Ok(await _patioService.ObterContagemPorSetorAsync(setor));

        [HttpGet("moto/{placa}/status")]
        public async Task<IActionResult> StatusIndividual(string placa) => Ok(await _patioService.ObterStatusPorPlacaAsync(placa));

        [HttpGet("status")]
        public async Task<IActionResult> StatusGeral() => Ok(await _patioService.ObterResumoStatusAsync());
    }
}