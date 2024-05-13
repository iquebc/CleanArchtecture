using CleanArchtectureMVC.Application.Products.Commands;
using CleanArchtectureMVC.Domain.Interface;
using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;

        public ProductRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            Product? product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null) throw new ApplicationException("Product could not be found");

            return await _productRepository.RemoveAsync(product);
        }
    }
}