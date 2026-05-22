
using Domain.BaseEntity;
using Domain.Models.Ordera;

namespace Domain.Models.Products
{
    public class Product:BaseEntity<int>
    {
        
        public string Name { get; private set; } = string.Empty;
    
        public decimal Price { get; private set; }
        public int Qty {  get; private set; }
        public Mechanicalproppertis Property { get; private set; } 
        public ICollection<OrderItems> Items { get; }

        public Product( string name, decimal price, int qty)
        {
            
           this.Name = name;
           this.Price = price;
           this.Qty = qty;
        }
      public void SetProperty(Mechanicalproppertis mechanicalproppertis)
        {
            Property= mechanicalproppertis;
        }
        public void  Update( string name, decimal price, int qty)
        {
            Name = name;
            Price = price;
            Qty = qty;
        }
    }
}
