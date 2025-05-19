using AutoMapper;
using Mottu.Application.DTOs;
using Mottu.Application.Interfaces;
using Mottu.Domain.Entities;
using Mottu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Mottu.API.Services
{
    public class MotoService : IMotoService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MotoService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MotoDTO>> GetAllAsync()
        {
            var motos = await _context.Motos.ToListAsync();
            return _mapper.Map<IEnumerable<MotoDTO>>(motos);
        }

        public async Task<MotoDTO> GetByIdAsync(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            return moto is null ? throw new Exception("Moto não encontrada") : _mapper.Map<MotoDTO>(moto);
        }

        public async Task<MotoDTO> CreateAsync(MotoDTO dto)
        {
            var moto = _mapper.Map<Moto>(dto);
            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return _mapper.Map<MotoDTO>(moto);
        }

        public async Task<MotoDTO> UpdateAsync(int id, MotoDTO dto)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto is null) throw new Exception("Moto não encontrada");

            moto.AtualizarStatus(Enum.Parse<MotoStatus>(dto.Status));
            _mapper.Map(dto, moto);
            await _context.SaveChangesAsync();
            return _mapper.Map<MotoDTO>(moto);
        }

        public async Task DeleteAsync(int id)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto is null) throw new Exception("Moto não encontrada");

            _context.Motos.Remove(moto);
            await _context.SaveChangesAsync();
        }
    }
}
