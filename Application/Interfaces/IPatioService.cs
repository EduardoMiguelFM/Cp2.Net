using Mottu.Application.DTOs;

namespace Mottu.Application.Interfaces
{
    public interface IPatioService
    {
        Task<IEnumerable<PatioDTO>> GetAllAsync();
        Task<PatioDTO> GetByIdAsync(int id);
        Task<PatioDTO> CreateAsync(PatioDTO dto);
        Task<PatioDTO> UpdateAsync(int id, PatioDTO dto);
        Task DeleteAsync(int id);
    }
}
