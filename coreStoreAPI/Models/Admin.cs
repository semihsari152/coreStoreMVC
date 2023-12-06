using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace coreStoreAPI.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(40)]
        public string? Name { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string? Username { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string? Password { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string? Authority { get; set; }
    }
}
