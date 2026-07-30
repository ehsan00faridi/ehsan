namespace Domain.Models.Products
{
    public class ProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;

        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string Weight { get; set; }
        public string material { get; set; }
       
        public string? Img { get; set; }
      
    }
}
