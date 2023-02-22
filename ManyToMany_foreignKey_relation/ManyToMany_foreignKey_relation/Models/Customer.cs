using System.ComponentModel.DataAnnotations;

namespace ManyToMany_foreignKey_relation.Models
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
