using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IViewProductsByCategoryIdUseCase
    {
        IEnumerable<Product> Execute(int categoryId);
    }
}