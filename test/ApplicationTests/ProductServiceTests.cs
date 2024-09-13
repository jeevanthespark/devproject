using CleanArchitecture.MyShop.Application.Common.Interfaces;
using CleanArchitecture.MyShop.Application.Services;
using CleanArchitecture.MyShop.Domain.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NSubstitute;

namespace ApplicationTests;

public class ProductServiceTests
{
    private readonly IProductDbContext _mockProductDbContext;
    private readonly Fixture _fixture;
    private readonly ProductService _systemUnderTest;

    public ProductServiceTests()
    {
        _mockProductDbContext = Substitute.For<IProductDbContext>();
        _systemUnderTest = new ProductService(_mockProductDbContext);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task CreateProductAsync_Returns_Product()
    {
        //Arrange
        var product = _fixture.Create<Product>();
        _mockProductDbContext.Products.AddAsync(Arg.Any<Product>()).Returns(product);

        //Act
        var result = await _systemUnderTest.CreateProductAsync(product);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<Product>();
    }
}
