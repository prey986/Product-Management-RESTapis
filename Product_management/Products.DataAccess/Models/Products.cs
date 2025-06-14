using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.DataAccess.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Productname { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
