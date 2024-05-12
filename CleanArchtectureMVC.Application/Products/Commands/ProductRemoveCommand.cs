using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Products.Commands
{
    public class ProductRemoveCommand : IRequest<Product>
    {
        public int Id { get; set; }

        public ProductRemoveCommand(int id)
        {
            Id = id;
        }
    }
}