using coreStoreAPI.Context;
using coreStoreAPI.Models;
using coreStoreAPI.Models.Request.Product;

namespace coreStoreAPI.Services
{
    public interface IProductService
    {
        Product Insert(ProductRequestModel request);
        Product Update(int productId, ProductRequestModel request);
        void Delete(int productId);
        List<Product> GetList();
        Product? GetProductById(int id);
        List<Product> GetListByGender(string gender);
    }

    public class ProductService : IProductService
    {

        private readonly CoreContext _dbContext;

        public ProductService(CoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Delete(int productId)
        {
            var deleteItem = _dbContext.Products.FirstOrDefault(i => i.ProductID == productId);

            if (deleteItem != null)
            {
                deleteItem.ProductStatus = false;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("Belirtilen item bulunamadı.");
            }
        }

        public Product Insert(ProductRequestModel request)
        {
            var newProduct = new Product
            {
                ProductID = request.ProductID,
                ProductName = request.ProductName,
                ProductBrand = request.ProductBrand,
                ProductDetail = request.ProductDetail,
                ProductFeatures = request.ProductFeatures,
                AdditionalImages = request.AdditionalImages,
                MainProductImage = request.MainProductImage,
                ProductPrice = request.ProductPrice,
                ProductGender = request.ProductGender,
                ProductFreeShippingInfo = request.ProductFreeShippingInfo,
                SubCategoryID = request.SubCategoryID,
            };

            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();

            return newProduct;
        }

        public Product Update(int productId, ProductRequestModel request)
        {
            var updateItem = _dbContext.Products.FirstOrDefault(p => p.ProductID == productId);

            if (updateItem == null)
            {

                throw new InvalidOperationException("Belirtilen item bulunamadı.");
            }

            updateItem.ProductName = request.ProductName;
            updateItem.ProductDetail = request.ProductDetail;
            updateItem.ProductGender = request.ProductGender;
            updateItem.ProductPrice = request.ProductPrice;
            updateItem.ProductFeatures = request.ProductFeatures;
            updateItem.ProductBrand = request.ProductBrand;
            updateItem.ProductFreeShippingInfo = request.ProductFreeShippingInfo;
            updateItem.MainProductImage = request.MainProductImage;
            updateItem.AdditionalImages = request.AdditionalImages;

            _dbContext.SaveChanges();

            return updateItem;
        }

        public List<Product> GetList()
        {
            return _dbContext.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductID == id);
        }

        public List<Product> GetListByGender(string gender)
        {
            return _dbContext.Products.Where(p => p.ProductGender == gender).ToList();
        }
    }
}