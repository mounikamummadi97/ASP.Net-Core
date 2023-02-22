using System.ComponentModel.DataAnnotations;

namespace WebAPI_ForeignKey_Relations.Model
{
    public class Customer
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int CustomerAge { get; set; }
        public string? CustomerAddress { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

    }
}
