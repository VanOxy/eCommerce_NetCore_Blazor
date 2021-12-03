using CoreBusiness;
using System.Collections.Generic;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ICategoryRepository
    {
        public IEnumerable<Category> GetCategories();

        Category GetCategoryById(int categoryId);

        public void AddCategory(Category category);

        public void UpdateCategory(Category category);

        void Delete(int categoryId);
    }
}