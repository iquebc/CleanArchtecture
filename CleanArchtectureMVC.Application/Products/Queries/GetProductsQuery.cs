using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}