namespace Application.Dtos.products
{
    public class AddProductRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public string CategoryCreator { get; set; }
    }
}
