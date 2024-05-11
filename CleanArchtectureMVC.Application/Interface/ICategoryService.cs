using CleanArchtectureMVC.Application.DTOs;

namespace CleanArchtectureMVC.Application.Interface
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync();

        Task<CategoryDTO?> GetByIdAsync(int id);

        Task CreateAsync(CategoryDTO categoryDTO);

        Task UpdateAsync(CategoryDTO categoryDTO);

        Task RemoveAsync(int id);
    }
}