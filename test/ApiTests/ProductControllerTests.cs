using CleanArchitecture.MyShop.Api.Controllers;
using CleanArchitecture.MyShop.Application.Interfaces;
using CleanArchitecture.MyShop.Domain.Entities;
using FluentAssertions;
using Moq;

namespace ApiTests;

public class ProductControllerTests
{
    private ProductController _systemUnderTest;
    private Mock<IProductService> _mockProductService;

    [SetUp]
    public void Setup()
    {
        _mockProductService = new Mock<IProductService>();
        _systemUnderTest = new ProductController(_mockProductService.Object);
    }

    [Test]
    public async Task Test1()
    {
        //Arrange
        var products = new List<Product> { new Product { Id=1,Name="Product 1", Description="Confectionary", Stock=new Stock{
        Id= 1, PurchasedQuantity=10, RemainingQuantity=10, Created=DateTime.Now.AddDays(-2)},Created=DateTime.Now.AddDays(-2) } };
        _mockProductService.Setup(x => x.GetAllProductsAsync()).ReturnsAsync(products);

        //Act
        var result = await _systemUnderTest.GetAllProducts();

        //Assert
        result.Should().NotBeNull();
    }
}