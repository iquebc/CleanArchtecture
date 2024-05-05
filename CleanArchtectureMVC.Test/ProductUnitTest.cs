using CleanArchtectureMVC.Domain.Model;
using CleanArchtectureMVC.Domain.Validation;

namespace CleanArchtectureMVC.Test;

public class ProductUnitTest
{
    [Fact]
    public void ShouldCreateNewProduct()
    {
        Product product = Product.NewProduct("New Product", "Test new Product", 10, 100, "image");
        Assert.Equal(0, product.Id);
        Assert.Equal("New Product", product.Name);
        Assert.Equal("Test new Product", product.Description);
        Assert.Equal(10, product.Price);
        Assert.Equal(100, product.Stock);
        Assert.Equal("image", product.Image);
    }

    [Fact]
    public void ShouldCreateCategoryWithIdHigherThenZero()
    {
        Product product = new Product(10, "New Product", "Test new Product", 10, 100, "image");
        Assert.Equal(10, product.Id);
        Assert.Equal("New Product", product.Name);
        Assert.Equal("Test new Product", product.Description);
        Assert.Equal(10, product.Price);
        Assert.Equal(100, product.Stock);
        Assert.Equal("image", product.Image);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameIsEmpty()
    {
        Action action = () => Product.NewProduct("", "Test new Product", 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Name Is Required", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameWithWhiteSpace()
    {
        Action action = () => Product.NewProduct("        ", "Test new Product", 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Name Is Required", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameIsNull()
    {
        Action action = () => Product.NewProduct(null, "Test new Product", 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Name Is Required", exception.Message);
    }


    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameIsTooSmall()
    {
        Action action = () => Product.NewProduct("as", "Test new Product", 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Name too small, minimum 3 characters", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenDescriptionIsEmpty()
    {
        Action action = () => Product.NewProduct("New Product", "", 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Description Is Required", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenDescriptionWithWhiteSpace()
    {
        Action action = () => Product.NewProduct("New Product", "        ", 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Description Is Required", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenDescriptionIsNull()
    {
        Action action = () => Product.NewProduct("New Product", null, 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Description Is Required", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenDescriptionIsTooSmall()
    {
        Action action = () => Product.NewProduct("New Product", "Test", 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Description too small, minimum 5 characters", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenIdIsNegative()
    {
        Action action = () => new Product(-1, "New Product", "Test new Product", 10, 100, "image");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Invalid Id Value", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenPriceIsNegative()
    {
        Action action = () => Product.NewProduct("New Product", "Test new Product", -10, 100, "image"); ;
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Invalid price value", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenStockIsNegative()
    {
        Action action = () => Product.NewProduct("New Product", "Test new Product", 10, -1, "image"); ;
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Invalid stock value", exception.Message);
    }

    [Fact]
    public void ShouldCreateNewProductWithNullImage()
    {
        Product product = Product.NewProduct("New Product", "Test new Product", 10, 100, null);
        Assert.Equal(String.Empty, product.Image);
    }

    [Fact]
    public void ShouldCreateNewProductWithEmptyImage()
    {
        Product product = Product.NewProduct("New Product", "Test new Product", 10, 100, "");
        Assert.Equal(String.Empty, product.Image);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameIsTooBig()
    {
        Action action = () => Product.NewProduct("New Product", "Test new Product", 10, 100, "aihsiudhaiushdiahsduiahsdiuashdiuahsdiaushdaiushduiashduiashdiuashuidhsauidhasiuhdasiudhauishduiasdhauishdauishdiuashduiashdauishdiuashdiuashduiahsdiuashuidhasuidhasuidhausidhaisudhasiudhasuidhasuidhauishdaisudhaiusdhaisudhaiushdasuidhasiuhdaiushdisudhaisudhaisudhasiudhasiudhasiudhasiudh");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Invalid Image Name, maximum 250 characters", exception.Message);
    }

    [Fact]
    public void ShouldUpdateProductWithNewValidName()
    {
        Product Arrange = new Product(10, "Existent Product", "Existent Description", 10, 100, "image");
        Product UpdatedArrange = Arrange.UpdateProduct("Updated Product", Arrange.Description, Arrange.Price, Arrange.Stock, Arrange.Image);
        Assert.Equal(10, UpdatedArrange.Id);
        Assert.Equal("Updated Product", UpdatedArrange.Name);
    }

    [Fact]
    public void ShouldUpdateProductWithNewValidDescription()
    {
        Product Arrange = new Product(10, "Existent Product", "Existent Description", 10, 100, "image");
        Product UpdatedArrange = Arrange.UpdateProduct(Arrange.Name, "Updated Description", Arrange.Price, Arrange.Stock, Arrange.Image);
        Assert.Equal(10, UpdatedArrange.Id);
        Assert.Equal("Updated Description", UpdatedArrange.Description);
    }

    [Fact]
    public void ShouldUpdateProductWithNewValidPrice()
    {
        Product Arrange = new Product(10, "Existent Product", "Existent Description", 10, 100, "image");
        Product UpdatedArrange = Arrange.UpdateProduct(Arrange.Name, Arrange.Description, 20, Arrange.Stock, Arrange.Image);
        Assert.Equal(10, UpdatedArrange.Id);
        Assert.Equal(20, UpdatedArrange.Price);
    }

    [Fact]
    public void ShouldUpdateProductWithNewValidStock()
    {
        Product Arrange = new Product(10, "Existent Product", "Existent Description", 10, 100, "image");
        Product UpdatedArrange = Arrange.UpdateProduct(Arrange.Name, Arrange.Description, Arrange.Price, 10, Arrange.Image);
        Assert.Equal(10, UpdatedArrange.Id);
        Assert.Equal(10, UpdatedArrange.Stock);
    }

    [Fact]
    public void ShouldUpdateProductWithNewValidImage()
    {
        Product Arrange = new Product(10, "Existent Product", "Existent Description", 10, 100, "image");
        Product UpdatedArrange = Arrange.UpdateProduct(Arrange.Name, Arrange.Description, Arrange.Price, Arrange.Stock, "Updated Image");
        Assert.Equal(10, UpdatedArrange.Id);
        Assert.Equal("Updated Image", UpdatedArrange.Image);
    }
}