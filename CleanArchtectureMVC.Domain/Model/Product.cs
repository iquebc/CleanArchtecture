using CleanArchtectureMVC.Domain.Validation;

namespace CleanArchtectureMVC.Domain.Model
{
    public sealed class Product : Entity
    {

        #region :: Propertys

        private string name;
        public string Name
        {
            get { return name; }
            private set
            {
                DomainExceptionValidation.When(String.IsNullOrWhiteSpace(value), "Name Is Required");
                DomainExceptionValidation.When(value.Length < 3, "Name too small, minimum 3 characters");

                name = value;
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            private set
            {
                DomainExceptionValidation.When(String.IsNullOrWhiteSpace(value), "Description Is Required");
                DomainExceptionValidation.When(value.Length < 5, "Description too small, minimum 5 characters");

                description = value;
            }
        }

        private decimal price;
        public decimal Price
        {
            get { return price; }
            private set
            {
                DomainExceptionValidation.When(value < 0, "Invalid price value");
                price = value;
            }
        }

        private int stock;
        public int Stock
        {
            get { return stock; }
            private set
            {
                DomainExceptionValidation.When(value < 0, "Invalid stock value");
                stock = value;
            }
        }

        private string image;
        public string Image
        {
            get { return image; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    image = String.Empty;
                }
                else
                {
                    DomainExceptionValidation.When(value.Length > 250, "Invalid Image Name, maximum 250 characters");
                    image = value;
                }
            }
        }

        private int categoryId;
        public int CategoryId
        {
            get
            {
                return categoryId;
            }
            private set
            {
                DomainExceptionValidation.When(value <= 0, "Invalid Category");
                categoryId = value;
            }
        }

        public Category Category { get; set; }

        #endregion

        #region :: Constructors

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId) : base(id)
        {
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
        }

        #endregion

        #region :: Methods
        public static Product NewProduct(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            return new Product(0, name, description, price, stock, image, categoryId);
        }

        public Product UpdateProduct(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            return new Product(Id, name, description, price, stock, image, categoryId);
        }

        #endregion
    }
}