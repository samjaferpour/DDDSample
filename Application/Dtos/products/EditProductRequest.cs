namespace Application.Dtos.products
{
    public class EditProductRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCreator { get; set; }
    }
}
