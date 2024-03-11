using MediatR;

namespace Web.Controllers
{
    public class BaseController
    {
        protected readonly IMediator _mediator;
        protected Serilog.ILogger _logger;

        public BaseController(IMediator mediator, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
    }
}
