namespace Mottu.Application.Interfaces
{
    using Mottu.Application.DTOs;

    public interface IMotoService
    {
        Task<IEnumerable<MotoDTO>> GetAllAsync();
        Task<MotoDTO> GetByIdAsync(int id);
        Task<MotoDTO> CreateAsync(MotoDTO dto);
        Task<MotoDTO> UpdateAsync(int id, MotoDTO dto);
        Task DeleteAsync(int id);
    }

}
