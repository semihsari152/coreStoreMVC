using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace coreStoreAPI.Models.Request.Product
{
    public class ProductRequestModel
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductBrand { get; set; }
        public string? ProductDetail { get; set; }
        public string? ProductFeatures { get; set; }
        public string? MainProductImage { get; set; } // Ana görsel için alan
        public List<ProductImage>? AdditionalImages { get; set; } // Diğer görseller için liste
        public decimal ProductPrice { get; set; }
        public string? ProductGender { get; set; }
        public bool ProductFreeShippingInfo { get; set; }
        public int SubCategoryID { get; set; }
    }
}