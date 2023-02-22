using System.ComponentModel.DataAnnotations;

namespace API_JWT_Authentication.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerAddress { get; set; }
        
    }
}
