﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Photos = new HashSet<Photo>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Details { get; set; }
        public bool Status { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
    }
}
