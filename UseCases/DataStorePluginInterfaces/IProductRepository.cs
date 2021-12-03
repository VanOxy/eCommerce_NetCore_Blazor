using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();

        Product GetProductById(int productId);

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void Delete(int productId);
    }
}