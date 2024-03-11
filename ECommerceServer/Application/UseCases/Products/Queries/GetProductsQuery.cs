using Application.DTOs;
using MediatR;

namespace Application.UseCases.Products.Queries
{
    public class GetProductsQuery : IRequest<List<ProductDTO>>
    {
    }
}
