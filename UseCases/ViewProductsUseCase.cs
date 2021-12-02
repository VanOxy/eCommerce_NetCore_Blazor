using CoreBusiness;
using System.Collections.Generic;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewProductsUseCase : IViewProductsUseCase
    {
        private readonly IProductRepository productsRepository;

        public ViewProductsUseCase(IProductRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IEnumerable<Product> Execute()
        {
            return productsRepository.GetProducts();
        }
    }
}