namespace Mottu.API.Services
{
    using AutoMapper;
    using Mottu.Application.DTOs;
    using Mottu.Application.Interfaces;
    using Mottu.Domain.Entities;
    using Mottu.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;

    public class UsuarioPatioService : IUsuarioPatioService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UsuarioPatioService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioPatioDTO>> GetAllAsync()
        {
            var usuarios = await _context.UsuariosPatio.ToListAsync();
            return _mapper.Map<IEnumerable<UsuarioPatioDTO>>(usuarios);
        }

        public async Task<UsuarioPatioDTO> GetByIdAsync(int id)
        {
            var usuario = await _context.UsuariosPatio.FindAsync(id);
            return usuario is null ? throw new Exception("Usuário não encontrado") : _mapper.Map<UsuarioPatioDTO>(usuario);
        }

        public async Task<UsuarioPatioDTO> CreateAsync(UsuarioPatioDTO dto)
        {
            var usuario = _mapper.Map<UsuarioPatio>(dto);
            _context.UsuariosPatio.Add(usuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioPatioDTO>(usuario);
        }

        public async Task<UsuarioPatioDTO> UpdateAsync(int id, UsuarioPatioDTO dto)
        {
            var usuario = await _context.UsuariosPatio.FindAsync(id);
            if (usuario is null) throw new Exception("Usuário não encontrado");

            _mapper.Map(dto, usuario);
            await _context.SaveChangesAsync();
            return _mapper.Map<UsuarioPatioDTO>(usuario);
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.UsuariosPatio.FindAsync(id);
            if (usuario is null) throw new Exception("Usuário não encontrado");

            _context.UsuariosPatio.Remove(usuario);
            await _context.SaveChangesAsync();
        }
    }
}
