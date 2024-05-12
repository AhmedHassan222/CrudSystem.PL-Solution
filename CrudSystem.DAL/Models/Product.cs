using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSystem.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public int Code { get; set; }

        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public int NumberOfBoun { get; set; }
        

    }
}
