using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }

        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}