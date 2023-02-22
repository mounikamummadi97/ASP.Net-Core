using System.ComponentModel.DataAnnotations;

namespace OneToMany_foreignKey_Relation.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerAge { get; set; } 
        public string CustomerAddress { get; set; }

    }
}
