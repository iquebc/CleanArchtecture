using AutoMapper;
using CleanArchtectureMVC.Application.DTOs;
using CleanArchtectureMVC.Application.Interface;
using CleanArchtectureMVC.Application.Products.Commands;
using CleanArchtectureMVC.Application.Products.Queries;
using CleanArchtectureMVC.Domain.Interface;
using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Service
{
    public class ProductService : IProductService
    {
        private IMediator _mediator;
        private readonly IMapper _mapper;
        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            GetProductsQuery productsQuery = new GetProductsQuery();

            if (productsQuery == null) throw new Exception("Products Query could not be loaded");

            IEnumerable<Product> products = await _mediator.Send(productsQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task<ProductDTO?> GetByIdAsync(int id)
        {
            GetProductByIdQuery getProductByIdQuery = new GetProductByIdQuery(id);

            if (getProductByIdQuery == null) throw new Exception("getProductByIdQuery could not be loaded");

            Product? product = await _mediator.Send(getProductByIdQuery);

            return _mapper.Map<ProductDTO>(product);
        }

        public async Task<IEnumerable<ProductDTO>> GetProductsByCategoryAsync(int idCategory)
        {
            GetProductByCategoryIdQuery getProductByCategoryIdQuery = new GetProductByCategoryIdQuery(idCategory);

            if (getProductByCategoryIdQuery == null) throw new Exception("getProductByCategoryIdQuery could not be loaded");

            IEnumerable<Product> products = await _mediator.Send(getProductByCategoryIdQuery);

            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }

        public async Task CreateAsync(ProductDTO productDTO)
        {
            ProductCreateCommand productCreateCommand = _mapper.Map<ProductCreateCommand>(productDTO);
            await _mediator.Send(productCreateCommand);
        }

        public async Task UpdateAsync(ProductDTO productDTO)
        {
            ProductUpdateCommand productUpdateCommand = _mapper.Map<ProductUpdateCommand>(productDTO);
            await _mediator.Send(productUpdateCommand);
        }

        public async Task RemoveAsync(int id)
        {
            ProductRemoveCommand productRemoveCommand = new ProductRemoveCommand(id);

            if (productRemoveCommand == null) throw new Exception("productRemoveCommand could not be loaded");

            await _mediator.Send(productRemoveCommand);
        }
    }
}