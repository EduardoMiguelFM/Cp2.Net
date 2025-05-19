using AutoMapper;
using Mottu.Application.DTOs;
using Mottu.Application.Interfaces;
using Mottu.Domain.Entities;
using Mottu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace Mottu.API.Services
{ 
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

            _mapper.Map(dto, patio);
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
    }

}
