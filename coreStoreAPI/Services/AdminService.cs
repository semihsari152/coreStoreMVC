using coreStoreAPI.Context;
using coreStoreAPI.Models.Request.Category;
using coreStoreAPI.Models;
using coreStoreAPI.Models.Request.Admin;
using coreStoreAPI.Models.Request.Product;

namespace coreStoreAPI.Services
{
    public interface IAdminService
    {
        Product InsertProduct(ProductRequestModel request);
        Product UpdateProduct(int adminId, ProductRequestModel request);
        void DeleteProduct(int productID);
        List<Product> GetList();
        Product? GetProductById(int id);
    }
}