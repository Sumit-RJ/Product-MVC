using Product_MVC.Models;

namespace Product_MVC.Repositories
{
    public interface IProductRepository
    {
        public Task<List<ProductViewModel>> GetAllProducts();
        public Task<ProductViewModel> CreateProduct(ProductViewModel product);
    }
}
