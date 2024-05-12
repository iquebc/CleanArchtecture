using CleanArchtectureMVC.Domain.Model;
using MediatR;

namespace CleanArchtectureMVC.Application.Products.Queries
{
    public class GetProductByCategoryIdQuery : IRequest<IEnumerable<Product>>
    {
        public int IdCategory { get; set; }

        public GetProductByCategoryIdQuery(int idCategory)
        {
            IdCategory = idCategory;
        }
    }
}