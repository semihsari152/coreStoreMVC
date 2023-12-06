using System.ComponentModel.DataAnnotations;

namespace coreStoreAPI.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryID { get; set; }
        public string? SubCategoryName { get; set; }
        public bool SubCategoryStatus { get; set; }
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}