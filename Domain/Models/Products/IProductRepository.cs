using Domain.BaseRepository;

namespace Domain.Models.Products
{
    public interface IProductRepository:IBaseRepository<Product,int>
    {
        Task<IEnumerable<ProductDto>> GetAllProducts();
       
        Task<ProductDto> GetProductById(int id);
    }
}
