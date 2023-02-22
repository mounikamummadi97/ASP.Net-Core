using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public String? ProductName { get; set; }
        public int ProductPrice { get; set; }
    }
}
