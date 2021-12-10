using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MarketContext db;

        public ProductRepository(MarketContext db)
        {
            this.db = db;
        }

        public void AddProduct(Product product)
        {
            db.Products.Add(product);
        }

        public void Delete(int productId)
        {
            var prod = db.Products.Find(productId);
            if (prod == null) return;
            db.Products.Remove(prod);
            db.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return db.Products.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return db.Products.ToList();
        }

        public IEnumerable<Product> GetProductsByCategoryId(int categoryId)
        {
            return db.Products.Where(c => c.CategoryId == categoryId).ToList();
        }

        public void UpdateProduct(Product product)
        {
            var prod = db.Products.Find(product.ProductId);
            if (prod == null) return;
            prod.ProductId = product.ProductId;
            prod.Name = product.Name;
            prod.Price = product.Price;
            prod.Quantity = product.Quantity;
            db.SaveChanges();
        }
    }
}