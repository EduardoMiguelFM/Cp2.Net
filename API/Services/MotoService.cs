using AutoMapper;
using Mottu.Application.DTOs;
using Mottu.Application.Interfaces;
using Mottu.Domain.Entities;
using Mottu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Mottu.API.Services
{ 

    using AutoMapper;
    using Mottu.Application.DTOs;
    using Mottu.Application.Interfaces;
    using Mottu.Domain.Entities;
    using Mottu.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

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
            var motos = await _context.Motos.Include(m => m.Patio).ToListAsync();
            return _mapper.Map<IEnumerable<MotoDTO>>(motos);
        }

        public async Task<MotoDTO> GetByIdAsync(int id)
        {
            var moto = await _context.Motos.Include(m => m.Patio).FirstOrDefaultAsync(m => m.Id == id);
            return moto is null ? throw new Exception("Moto não encontrada") : _mapper.Map<MotoDTO>(moto);
        }

        public async Task<MotoDTO> CreateAsync(MotoDTO dto)
        {
            var patio = await _context.Patios.FirstOrDefaultAsync(p => p.Nome == dto.NomePatio);
            if (patio is null) throw new Exception("Pátio não encontrado");

            var moto = new Moto
            {
                Modelo = dto.Modelo,
                Placa = dto.Placa,
                Status = Enum.Parse<MotoStatus>(dto.Status),
                PatioId = patio.Id,
                Patio = patio
            };

            _context.Motos.Add(moto);
            await _context.SaveChangesAsync();
            return _mapper.Map<MotoDTO>(moto);
        }

        public async Task<MotoDTO> UpdateAsync(int id, MotoDTO dto)
        {
            var moto = await _context.Motos.FindAsync(id);
            if (moto is null) throw new Exception("Moto não encontrada");

            var patio = await _context.Patios.FirstOrDefaultAsync(p => p.Nome == dto.NomePatio);
            if (patio is null) throw new Exception("Pátio não encontrado");

            moto.Modelo = dto.Modelo;
            moto.Placa = dto.Placa;
            moto.Status = Enum.Parse<MotoStatus>(dto.Status);
            moto.PatioId = patio.Id;
            moto.Patio = patio;

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