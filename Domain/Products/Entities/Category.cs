namespace Domain.Products.Entities
{
    public class Category
    {
        public string Name { get; private set; }
        public string Creator { get; private set; }


        public Category(string name, string creator)
        {
            SetName(name);
            SetCreator(creator);
        }
        private Category() { }

        private void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Name cannot be empty.", nameof(name));
            Name = name;
        }

        private void SetCreator(string creator)
        {
            if (string.IsNullOrEmpty(creator))
                throw new ArgumentException("Creator cannot be empty.", nameof(creator));
            Creator = creator;
        }
    }
}
