using Domain.Products.ValueObjects;

namespace Domain.Products.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Money Price { get; private set; }
        internal Category Category { get; private set; }

        // Public accessors for Category properties
        public string CategoryName => Category.Name;
        public string CategoryCreator => Category.Creator;

        public Product(string name, Money price, string categoryName, string categoryCreator)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetPrice(price);
            Category = new Category(categoryName, categoryCreator);
        }

        private Product() { }

        public void UpdateName(string name)
        {
            SetName(name);
        }

        public void UpdatePrice(Money price)
        {
            SetPrice(price);
        }

        public void UpdateCategory(string categoryName, string categoryCreator)
        {
            Category = new Category(categoryName, categoryCreator);
        }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            Name = name;
        }

        private void SetPrice(Money price) 
        {
            if (price == null)
                throw new ArgumentNullException(nameof(price), "Price cannot be null.");
            Price = price;
        }
    }
}
