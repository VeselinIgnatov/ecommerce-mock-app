using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Queries
{
    public class GetProductsSliceQuery : IRequest<List<ProductDTO>>
    {
        public int Skip { get; set; }

        public int Take { get; set; }
    }
}
