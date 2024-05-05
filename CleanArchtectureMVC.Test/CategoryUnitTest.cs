using CleanArchtectureMVC.Domain.Model;
using CleanArchtectureMVC.Domain.Validation;

namespace CleanArchtectureMVC.Test;

public class CategoryUnitTest
{
    [Fact]
    public void ShouldCreateNewCategory()
    {
        Category category = Category.NewCategory("new category");
        Assert.True(category.Id == 0);
        Assert.True(category.Name == "new category");
    }

    [Fact]
    public void ShouldCreateCategoryWithIdHigherThenZero()
    {
        Category Arrange = new Category(10, "Existent Category");
        Assert.True(Arrange.Id == 10);
        Assert.True(Arrange.Name == "Existent Category");
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameIsEmpty()
    {
        Action action = () => Category.NewCategory("");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Name Is Required", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameWithWhiteSpace()
    {
        Action action = () => Category.NewCategory("              ");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Name Is Required", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameIsNull()
    {
        Action action = () => Category.NewCategory(null);
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Name Is Required", exception.Message);
    }


    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenNameIsTooSmall()
    {
        Action action = () => Category.NewCategory("as");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Name too small, minimum 3 characters", exception.Message);
    }

    [Fact]
    public void ShouldThrowDomainExceptionValidationWhenIdIsNegative()
    {
        Action action = () => new Category(-1, "Invalid Id");
        DomainExceptionValidation exception = Assert.Throws<DomainExceptionValidation>(action);
        Assert.Equal("Invalid Id Value", exception.Message);
    }

    [Fact]
    public void ShouldUpdateCategoryWithNewName()
    {
        Category Arrange = new Category(10, "Existent Category");
        Category UpdatedArrange = Arrange.UpdateCategory("Updated Category");
        Assert.True(UpdatedArrange.Id == 10);
        Assert.True(UpdatedArrange.Name == "Updated Category");
    }
}