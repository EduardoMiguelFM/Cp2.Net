namespace Mottu.API.Services
{
    using AutoMapper;
    using Mottu.Application.DTOs;
    using Mottu.Application.Interfaces;
    using Mottu.Domain.Entities;
    using Mottu.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class PatioService : IPatioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public PatioService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PatioDTO>> GetAllAsync()
        {
            var patios = await _context.Patios.ToListAsync();
            return _mapper.Map<IEnumerable<PatioDTO>>(patios);
        }

        public async Task<PatioDTO> GetByIdAsync(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            return patio is null ? throw new Exception("Pátio não encontrado") : _mapper.Map<PatioDTO>(patio);
        }

        public async Task<PatioDTO> CreateAsync(PatioDTO dto)
        {
            var patio = _mapper.Map<Patio>(dto);
            _context.Patios.Add(patio);
            await _context.SaveChangesAsync();
            return _mapper.Map<PatioDTO>(patio);
        }

        public async Task<PatioDTO> UpdateAsync(int id, PatioDTO dto)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio is null) throw new Exception("Pátio não encontrado");

            patio.Nome = dto.Nome;

            await _context.SaveChangesAsync();
            return _mapper.Map<PatioDTO>(patio);
        }

        public async Task DeleteAsync(int id)
        {
            var patio = await _context.Patios.FindAsync(id);
            if (patio is null) throw new Exception("Pátio não encontrado");

            _context.Patios.Remove(patio);
            await _context.SaveChangesAsync();
        }

        public async Task<object> ObterContagemPorSetorAsync(string setor)
        {
            var motos = await _context.Motos.Where(m => m.Setor.EndsWith(setor, StringComparison.OrdinalIgnoreCase)).ToListAsync();
            var status = motos.FirstOrDefault()?.Status.ToString() ?? "";
            return new { status, quantidade = motos.Count };
        }

        public async Task<object> ObterStatusPorPlacaAsync(string placa)
        {
            var moto = await _context.Motos.FirstOrDefaultAsync(m => m.Placa == placa);
            if (moto == null) throw new Exception("Moto não encontrada");
            return new { status = moto.Status.ToString(), setor = moto.Setor, cor = moto.Cor };
        }

        public async Task<Dictionary<string, int>> ObterResumoStatusAsync()
        {
            var statusContagem = await _context.Motos
                .GroupBy(m => m.Status)
                .Select(g => new { Status = g.Key.ToString(), Quantidade = g.Count() })
                .ToListAsync();

            return statusContagem.ToDictionary(x => x.Status, x => x.Quantidade);
        }
    }
}
