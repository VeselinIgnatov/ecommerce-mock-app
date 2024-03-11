using Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.Queries
{
    public class SearchProductQuery: IRequest<List<ProductDTO>>
    {
        public string Search { get; set; }
    }
}
