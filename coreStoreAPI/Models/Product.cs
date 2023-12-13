using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreStoreAPI.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string? ProductName { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string? ProductBrand { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string? ProductDetail { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string? ProductFeatures { get; set; }


        public string? MainProductImage { get; set; } // Ana görsel için alan
        public List<ProductImage>? AdditionalImages { get; set; } // Diğer görseller için liste
        public decimal ProductPrice { get; set; }
        public string? ProductGender { get; set; }
        public DateTime ProductCreateDate { get; set; }
        public DateTime ProductUpdateDate { get; set; }
        public bool ProductFreeShippingInfo { get; set; }
        public bool ProductStatus { get; set; }

        public int SubCategoryID { get; set; }
        public SubCategory? SubCategory { get; set; }

        public ICollection<ProductDetail>? ProductDetails { get; set; }
        public ICollection<LikedProduct>? LikedProducts { get; set; }
    }
}
