using System.ComponentModel.DataAnnotations;

namespace coreStoreAPI.Models
{
    public class ReceiptDetail
    {
        [Key]
        public int ReceiptDetailsID { get; set; }
        public string? ReceiptDetailsDescription { get; set; }
        public int ReceiptDetailsQTY { get; set; } //qty
        public decimal ReceiptDetailsUnitPrice { get; set; }
        public decimal ReceiptDetailsTotal { get; set; }
        public int ReceiptID { get; set; }
        public Receipt? Receipt { get; set; }
    }
}
