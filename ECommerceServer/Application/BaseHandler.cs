using Application.Interfaces;
using AutoMapper;
using Domain;
using Microsoft.Extensions.Caching.Memory;
using Serilog;

namespace Application
{
    public class BaseHandler<T> where T: class, IAuditableEntity
    {
        protected readonly IMapper _mapper;
        protected readonly ILogger _logger;
        protected readonly IMemoryCache _cache;

        public BaseHandler(IMapper mapper, ILogger logger, IMemoryCache cache)
        {
            _mapper = mapper;
            _logger = logger;
            _cache = cache;
        }
    }
}
