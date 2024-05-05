using CleanArchtectureMVC.Domain.Validation;

namespace CleanArchtectureMVC.Domain.Model
{
    public abstract class Entity
    {
        private int id;
        public int Id
        {
            get { return id; }
            protected set
            {
                DomainExceptionValidation.When(value < 0, "Invalid Id Value");
                id = value;
            }
        }

        public Entity(int id)
        {
            Id = id;
        }
    }
}