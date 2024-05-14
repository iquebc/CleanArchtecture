using CleanArchtectureMVC.Application.Products.Commands;
using CleanArchtectureMVC.Domain.Interface;
using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null) throw new ApplicationException("Product could not be found");

            product.UpdateProduct(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

            return await _productRepository.UpdateAsync(product);
        }
    }
}