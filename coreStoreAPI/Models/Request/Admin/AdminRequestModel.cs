using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace coreStoreAPI.Models.Request.Admin
{
    public class AdminRequestModel
    {
        
        public int AdminID { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Authority { get; set; }
    }
}