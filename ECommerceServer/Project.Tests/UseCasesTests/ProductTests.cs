//using Application.DTOs;
//using Application.Interfaces;
//using Application.UseCases.Products.Queries;
//using AutoMapper;
//using Domain.Entities;
//using Microsoft.Extensions.Caching.Memory;
//using Moq;

//namespace Project.Tests.UseCasesTests
//{
//    public class ProductTests
//    {
//        [Test]
//        public async Task Handle_CachedProduct_ReturnsProductDTO()
//        {
//            // Arrange
//            var productId = Guid.NewGuid();
//            var cachedProduct = new ProductDTO { Id = productId, Name = "Cached Product" };

//            var cacheMock = new Mock<ICacheService>();
//            var dtoList = new List<ProductDTO>();
//            cacheMock.Setup(c => c.TryGetValue("ALL_PRODUCTS", out dtoList))
//                .Returns(true);
//            var mockCache = new MockCache(cacheMock.Object.);
//            var mapperMock = new Mock<IMapper>();
//            mapperMock.Setup(m => m.Map<ProductDTO>(It.IsAny<Product>()))
//                .Returns(cachedProduct);

//            var handler = new GetProductByIdQueryHandler(
//                mapperMock.Object,
//                null, // Mocked repository not needed for this test
//                cacheMock.Object.,
//                null  // Mocked logger not needed for this test
//            );

//            var query = new GetProductByIdQuery { Id = productId };

//            // Act
//            var result = await handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.AreEqual(productId, result.Id);
//            Assert.AreEqual("Cached Product", result.Name);
//        }


//        [Test]
//        public async Task Handle_NonCachedProduct_ReturnsProductDTO()
//        {
//            // Arrange
//            var productId = Guid.NewGuid();
//            var productFromDatabase = new Product { Id = productId, Name = "Database Product" };

//            var cacheMock = new Mock<IMemoryCache>();
//            var dtoList = new List<ProductDTO>();

//            cacheMock.Setup(c => c.TryGetValue("ALL_PRODUCTS", out dtoList))
//                .Returns(false);

//            var mapperMock = new Mock<IMapper>();
//            mapperMock.Setup(m => m.Map<ProductDTO>(It.IsAny<Product>()))
//                .Returns<ProductDTO>(null); // Simulate no cached product

//            var repositoryMock = new Mock<IProductRepository>();
//            repositoryMock.Setup(r => r.GetByIdAsync(productId))
//                .ReturnsAsync(productFromDatabase);

//            var handler = new GetProductByIdQueryHandler(
//                mapperMock.Object,
//                repositoryMock.Object,
//                cacheMock.Object,
//                null  // Mocked logger not needed for this test
//            );

//            var query = new GetProductByIdQuery { Id = productId };

//            // Act
//            var result = await handler.Handle(query, CancellationToken.None);

//            // Assert
//            Assert.NotNull(result);
//            Assert.AreEqual(productId, result.Id);
//            Assert.AreEqual("Database Product", result.Name);
//        }
//    }
//}
