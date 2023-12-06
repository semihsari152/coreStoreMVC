using System.ComponentModel.DataAnnotations;

namespace coreStoreAPI.Models
{
    public class LikedProduct
    {
        [Key]
        public int LikedProductID { get; set; }
        public string? UserID { get; set; }

        public int ProductID { get; set; }
        public Product? Product { get; set; }
    }
}
