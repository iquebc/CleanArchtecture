using CleanArchtectureMVC.Application.Products.Commands;
using CleanArchtectureMVC.Domain.Interface;
using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
        {
            Product product = Product.NewProduct(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);

            if (product == null) throw new ApplicationException("Error Creating Entity");

            return await _productRepository.CreateAsync(product);
        }
    }
}