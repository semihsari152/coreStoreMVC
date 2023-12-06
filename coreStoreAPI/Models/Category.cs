using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreStoreAPI.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }


        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string? CategoryName { get; set; }


        public bool CategoryStatus { get; set; }


        public ICollection<SubCategory>? SubCategories { get; set; }
    }
}