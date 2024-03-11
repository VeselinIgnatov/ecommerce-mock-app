using Application.DTOs;
using MediatR;

namespace Application.UseCases.Products.Queries
{
    public class GetProductsByIdsQuery : IRequest<List<ProductDTO>>
    {
        public List<Guid> Ids { get; set; }
    }
}

