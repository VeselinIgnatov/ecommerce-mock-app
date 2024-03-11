using Moq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Infrastructure;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Domain.Entities;
using Infrastructure.Repositories;
using Serilog;

namespace Project.Tests.RepositoryTests
{
    public class ProductRepositoryTests
    {
        private AppDbContext _context;
        private List<Product> _testProducts = new List<Product>
        {
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Name Test",
                Description = "Test Description",
                ImageUrl = "some url",
                Price = 5.20m,
                Quantity = 14,
                Rating = 4.1,
                Brand = new Brand
                {
                    Name = "Brand 1"
                }
            },
            new Product
            {
                Id = Guid.NewGuid(),
                Name = "Name",
                Description = "Description",
                ImageUrl = "some other url",
                Price = 25.0m,
                Quantity = 64,
                Rating = 2.1,
                Brand = new Brand
                {
                    Name = "Brand 1"
                }
            }
        };

        [SetUp]
        public void Setup()
        {
            var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
            .UseInternalServiceProvider(serviceProvider)
            .Options;

            _context = new AppDbContext(options, new Mock<ICurrentUserService>().Object);
            _context.Database.EnsureCreated();
        }

        [Test]
        public async Task Search_Returns_Subset()
        {
            var searched = _testProducts.ElementAt(0);
            _context.Products.AddRange(_testProducts);
            _context.SaveChanges();

            var repository = new ProductRepository(_context, new Mock<ILogger>().Object);

            var sut = repository.Search("Test").ToList();

            Assert.IsTrue(sut != null);
            Assert.IsTrue(sut.Count == 1);
            Assert.IsTrue(sut.ElementAt(0).Id == searched.Id);
        }

        [Test]
        public async Task Search_Returns_EmptyCollection_If_NoMatch()
        {
            _context.Products.AddRange(_testProducts);
            _context.SaveChanges();

            var repository = new ProductRepository(_context, new Mock<ILogger>().Object);

            var sut = repository.Search("Not existing").ToList();

            Assert.IsTrue(sut.Count == 0);
        }


        [Test]
        public async Task GetById_ReturnsEntity()
        {
            var searched = _testProducts.ElementAt(0);
            _context.Products.AddRange(_testProducts);
            _context.SaveChanges();

            var repository = new ProductRepository(_context, new Mock<ILogger>().Object);

            var sut = await repository.GetByIdAsync(searched.Id);

            Assert.IsTrue(sut != null);
            Assert.AreEqual(sut, searched);
            Assert.IsTrue(sut.Id == searched.Id);
        }

        [Test]
        public async Task GetAll_ReturnsAllEntities()
        {
            _context.Products.AddRange(_testProducts);
            _context.SaveChanges();

            var repository = new ProductRepository(_context, new Mock<ILogger>().Object);

            var sut = await repository.GetAll().ToListAsync();

            Assert.IsTrue(sut != null);
            Assert.AreEqual(sut.Count, _context.Products.Count());
        }

        [Test]
        public async Task Add_AddsNewEntities()
        {
            var first = _testProducts.ElementAt(0);

            _context.Products.Add(first);
            _context.SaveChanges();

            var repository = new ProductRepository(_context, new Mock<ILogger>().Object);
            var added = _testProducts.ElementAt(1);
            await repository.AddAsync(added);

            var sut = _context.Products.FirstOrDefault(x => x.Id == added.Id);

            Assert.IsTrue(sut != null);
            Assert.AreEqual(sut, added);
        }
    }
}
