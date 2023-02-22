using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Foreignkey_Creating_APIController.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public int CustomerAge { get; set; }

        public string? CustomerAddress { get; set; }
        public virtual ICollection<CustomerProduct>? CustomerProducts { get; set; }

    }
}
