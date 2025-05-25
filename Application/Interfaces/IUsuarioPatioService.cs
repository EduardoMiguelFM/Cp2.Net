namespace Mottu.Application.Interfaces
{
    using Mottu.Application.DTOs;
    public interface IUsuarioPatioService
    {
        Task<IEnumerable<UsuarioPatioDTO>> GetAllAsync();
        Task<UsuarioPatioDTO> GetByIdAsync(int id);
        Task<UsuarioPatioDTO> CreateAsync(UsuarioPatioDTO dto);
        Task<UsuarioPatioDTO> UpdateAsync(int id, UsuarioPatioDTO dto);
        Task DeleteAsync(int id);
    }
}