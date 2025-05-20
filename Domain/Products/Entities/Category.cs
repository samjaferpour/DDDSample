namespace Domain.Products.Entities
{
    internal class Category
    {
        internal string Name { get; private set; }
        internal string Creator { get; private set; }


        internal Category(string name, string creator)
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
