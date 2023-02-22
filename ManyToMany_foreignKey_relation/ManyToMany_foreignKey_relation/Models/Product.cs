using System.ComponentModel.DataAnnotations;

namespace ManyToMany_foreignKey_relation.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string? ProductName { get; set; }

        public int ProductPrice { get; set; }

        public virtual ICollection<CustomerProduct>? CustomerProducts { get; set; }

    }
}

