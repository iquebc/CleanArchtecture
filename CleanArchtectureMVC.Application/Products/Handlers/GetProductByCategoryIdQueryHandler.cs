using CleanArchtectureMVC.Application.Products.Queries;
using CleanArchtectureMVC.Domain.Interface;
using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Products.Handlers
{
    public class GetProductByCategoryIdQueryHandler : IRequestHandler<GetProductByCategoryIdQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductByCategoryIdQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsByCategoryAsync(request.IdCategory);
        }
    }
}