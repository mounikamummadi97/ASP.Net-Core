using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ManyToMany_foreignKey_relation.Models
{
    public class CustomerProduct
    {
        [Key]
        public long CustomerProductId { get; set; }
        [ForeignKey("CustomerId")]
        public int CustomerId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
    }
}
