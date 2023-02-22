using System.ComponentModel.DataAnnotations;

namespace WebAPI_ForeignKey_Relations.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int productPrice { get; set; }



    }
}
