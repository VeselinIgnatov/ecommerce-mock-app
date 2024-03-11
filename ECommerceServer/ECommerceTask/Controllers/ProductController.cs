using Application.DTOs;
using Application.UseCases.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : BaseController
    {
        public ProductController(IMediator mediator, Serilog.ILogger logger)
            : base(mediator, logger)
        {
        }

        // GET: ProductController
        [HttpGet(Name = "GetAll")]
        public async Task<List<ProductDTO>> GetAll()
        {
            return await _mediator.Send(new GetProductsQuery());
        }

        [HttpGet(Name = "GetById")]
        public async Task<ProductDTO> GetById([FromQuery] GetProductByIdQuery request)
        {
            _logger.Information("Receiving reqiest: ", request);
            return await _mediator.Send(request);
        }

        [HttpGet(Name = "GetByIds")]
        public async Task<List<ProductDTO>> GetByIds([FromQuery] GetProductsByIdsQuery request)
        {
            _logger.Information("Receiving reqiest: ", request);
            return await _mediator.Send(request);
        }

        [HttpGet(Name = "GetSlice")]
        public async Task<List<ProductDTO>> GetSlice(GetProductsSliceQuery request)
        {
            _logger.Information("Receiving reqiest: ", request);
            return await _mediator.Send(request);
        }


        [HttpGet(Name = "Search")]
        public async Task<List<ProductDTO>> Search([FromQuery] string search)
        {
            _logger.Information("Receiving request: ", search);

            return await _mediator.Send(new SearchProductQuery
            {
                Search = search
            });
        }
    }
}
