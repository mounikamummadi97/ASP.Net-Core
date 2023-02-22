using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OneToMany_foreignKey_Relation.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public String? ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set;}
    }
}
