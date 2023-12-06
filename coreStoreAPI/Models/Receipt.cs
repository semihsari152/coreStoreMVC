using System.ComponentModel.DataAnnotations;

namespace coreStoreAPI.Models
{
    public class Receipt
    {
        [Key]
        public int ReceiptID { get; set; }
        public string? ReceiptSerialNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
        public string? ReceiptTime { get; set; }
        public string? ReceiptReceiver { get; set; }//Teslim Alan
        public decimal ReceiptTotal { get; set; }
        public ICollection<ReceiptDetail>? ReceiptDetails { get; set; }
    }
}
