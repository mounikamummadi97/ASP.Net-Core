using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI_Ex2.Model
{
    public class Customer
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string? CustomerAddress { get; set; }

    }
    //public class Product
    //{
    //    [Key]
    //    public int ProductId { get; set; }
    //    public string ProductName { get; set; }
    //    public int productPrice { get; set; }
    //    public int CustomerId { get; set; }
    //    public Customer Customer { get; set; }
    //}
}
