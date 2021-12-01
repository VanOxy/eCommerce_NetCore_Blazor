using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();

        public void AddCategory(Category category);

        public void UpdateCategory(Category category);

        Category GetCategoryById(int categoryId);
    }
}