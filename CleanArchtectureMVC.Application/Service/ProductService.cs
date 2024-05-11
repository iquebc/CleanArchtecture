using AutoMapper;
using CleanArchtectureMVC.Application.DTOs;
using CleanArchtectureMVC.Application.Interface;
using CleanArchtectureMVC.Domain.Interface;
using CleanArchtectureMVC.Domain.Model;

namespace CleanArchtectureMVC.Application.Service
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            Product? product = await _productRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(int idCategory)
        {
            IEnumerable<Product> products = await _productRepository.GetProductsByCategoryAsync(idCategory);
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task CreateAsync(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            await _productRepository.CreateAsync(product);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            Product product = _mapper.Map<Product>(productDTO);
            await _productRepository.UpdateAsync(product);
        }

        public async Task RemoveAsync(int id)
        {
            Product? product = await _productRepository.GetByIdAsync(id);
            if (product == null) throw new ArgumentNullException(nameof(product));
            
            await _productRepository.RemoveAsync(product);
        }

    }
}