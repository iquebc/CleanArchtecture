using System.ComponentModel;
using CleanArchtectureMVC.Domain.Validation;

namespace CleanArchtectureMVC.Domain.Model
{
    public sealed class Category : Entity
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
        public ICollection<Product> Products { get; set; }

        #endregion

        #region :: Constructor

        public Category(int id, string name) : base(id)
        {
            Name = name;
        }

        #endregion

        #region :: Methods

        public static Category NewCategory(string name)
        {
            return new Category(0, name);
        }

        public Category UpdateCategory(string name)
        {
            return new Category(Id, name);
        }

        #endregion
    }
}