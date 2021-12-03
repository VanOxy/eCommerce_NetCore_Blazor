﻿using CoreBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace UseCases
{
    public class ViewProductsByCategoryIdUseCase : IViewProductsByCategoryIdUseCase
    {
        private readonly IProductRepository productRepository;

        public ViewProductsByCategoryIdUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> Execute(int categoryId)
        {
            return productRepository.GetProductsByCategoryId(categoryId);
        }
    }
}