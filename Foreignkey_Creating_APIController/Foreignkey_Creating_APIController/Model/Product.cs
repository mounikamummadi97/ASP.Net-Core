using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Foreignkey_Creating_APIController.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int productPrice { get; set; }
        public virtual ICollection<CustomerProduct>? CustomerProducts { get; set; }

    }
}
