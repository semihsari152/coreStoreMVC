using coreStoreAPI.Context;
using coreStoreAPI.Models.Request.Product;
using coreStoreAPI.Models;
using coreStoreAPI.Models.Request.Category;
using Microsoft.CodeAnalysis;

namespace coreStoreAPI.Services
{
    public interface ICategoryService
    {
        Category Insert(CategoryRequestModel request);
        Category Update(int productId, CategoryRequestModel request);
        void Delete(int productId);
        IEnumerable<Category> SearchProduct(string searchTerm);
        IEnumerable<Category> Get();
    }

    public class CategoryService : ICategoryService
    {

        private readonly CoreContext _dbContext;

        public CategoryService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int categoryId)
        {
            var deleteItem = _dbContext.Categories.FirstOrDefault(i => i.CategoryID == categoryId);

            if (deleteItem != null)
            {
                deleteItem.CategoryStatus = false;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Belirtilen item bulunamadı.");
            }
        }

        public IEnumerable<Category> Get()
        {
            var query = _dbContext.Categories.AsQueryable();

            return query.ToList();
        }

        public Category Insert(CategoryRequestModel request)
        {
            var newCategory = new Category
            {
                CategoryID = request.CategoryID,
                CategoryName = request.CategoryName,
                CategoryStatus = request.CategoryStatus
            };

            _dbContext.Categories.Add(newCategory);
            _dbContext.SaveChanges();

            return newCategory;
        }

        public IEnumerable<Category> SearchProduct(string searchTerm)
        {
            throw new NotImplementedException();
        }

        public Category Update(int categoryId, CategoryRequestModel request)
        {
            var updateItem = _dbContext.Categories.FirstOrDefault(p => p.CategoryID == categoryId);

            if (updateItem == null)
            {

                throw new InvalidOperationException("Belirtilen item bulunamadı.");
            }

            updateItem.CategoryID = request.CategoryID;
            updateItem.CategoryName = request.CategoryName;
            updateItem.CategoryStatus = request.CategoryStatus;

            _dbContext.SaveChanges();

            return updateItem;
        }
    }
}

