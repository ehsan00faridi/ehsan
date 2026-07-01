using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Products
{
    public class ProductDto
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }
        public int Qty { get; set; }
        public string Weight { get; set; }
        public string material { get; set; }
        //   public string? imgname { get; set; }
        public string? Img { get; set; }
        //public IFormFile? Imgfile { get; set; }
    }
}
