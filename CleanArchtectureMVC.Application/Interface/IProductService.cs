using CleanArchtectureMVC.Application.DTOs;

namespace CleanArchtectureMVC.Application.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync();

        Task<ProductDTO?> GetByIdAsync(int id);

        Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(int idCategory);

        Task CreateAsync(ProductDTO product);

        Task UpdateAsync(ProductDTO product);

        Task RemoveAsync(int id);
    }
}