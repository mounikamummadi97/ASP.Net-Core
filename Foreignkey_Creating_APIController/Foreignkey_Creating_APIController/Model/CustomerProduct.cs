using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Foreignkey_Creating_APIController.Model
{
    public class CustomerProduct
    {
        [Key]
        public long CustomerProductId { get; set; }
       
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer customer { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product product { get; set; }

    }
}
