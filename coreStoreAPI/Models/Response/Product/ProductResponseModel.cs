namespace coreStoreAPI.Models.Response.Product
{
    public class ProductResponseModel
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? ProductBrand { get; set; }
        public string? ProductDetail { get; set; }
        public string? ProductFeatures { get; set; }
        public string? MainProductImage { get; set; }
        public List<string>? AdditionalImages { get; set; }
        public decimal ProductPrice { get; set; }
        public string? ProductGender { get; set; }
        public DateTime ProductCreateDate { get; set; }
        public DateTime ProductUpdateDate { get; set; }
        public bool ProductFreeShippingInfo { get; set; }
        public bool ProductStatus { get; set; }
        public int SubCategoryID { get; set; }
    }

}