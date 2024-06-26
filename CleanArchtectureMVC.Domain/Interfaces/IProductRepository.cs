using CleanArchtectureMVC.Domain.Model;

namespace CleanArchtectureMVC.Domain.Interface
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();

        Task<Product?> GetByIdAsync(int id);

        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int idCategory);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> RemoveAsync(Product product);
    }
}