using Application.DTOs;
using MediatR;

namespace Application.UseCases.Products.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDTO>
    {
        public Guid Id { get; set; } 
    }
}
