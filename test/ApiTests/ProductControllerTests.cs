using CleanArchitecture.MyShop.Api.Controllers;
using CleanArchitecture.MyShop.Application.Interfaces;
using CleanArchitecture.MyShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTests;

public class ProductControllerTests
{
    private readonly ProductController _systemUnderTest;
    private readonly IProductService _mockProductService;
    private readonly Fixture _fixture;

    public ProductControllerTests()
    {
        _mockProductService = Substitute.For<IProductService>();
        _systemUnderTest = new ProductController(_mockProductService);
        _fixture = new Fixture();
    }

    [Fact]
    public async Task GetAllProducts_Returns_OkResult()
    {
        //Arrange
        var products = _fixture.CreateMany<Product>(3).ToList();
        _mockProductService.GetAllProductsAsync().Returns(products);

        //Act
        var result = await _systemUnderTest.GetAllProducts();

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>()
            .Which.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(products);
    }

    [Fact]
    public async Task GetProductsById_Returns_OkResult()
    {
        //Arrange
        var product = _fixture.Create<Product>();
        _mockProductService.GetByIdAsync(Arg.Any<int>()).Returns(product);

        //Act
        var result = await _systemUnderTest.GetProductById(1);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>()
            .Which.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(product);
    }

    [Fact]
    public async Task CreateProduct_Returns_OkResult()
    {
        //Arrange
        var product = _fixture.Create<Product>();
        _mockProductService.CreateProductAsync(product).Returns(product);

        //Act
        var result = await _systemUnderTest.CreateProduct(product);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>()
            .Which.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(product);
    }

    [Fact]
    public async Task UpdateProduct_Returns_OkResult()
    {
        //Arrange
        var product = _fixture.Create<Product>();
        _mockProductService.UpdateProductAsync(product).Returns(product);

        //Act
        var result = await _systemUnderTest.UpdateProduct(product);

        //Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<OkObjectResult>()
            .Which.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<OkObjectResult>()
            .Which.Value.Should().BeEquivalentTo(product);
    }
}