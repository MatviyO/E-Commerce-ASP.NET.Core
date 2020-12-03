using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    
    [Table("Photo")]
    public partial class Photo
    {
        public Photo()
        {
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int ProductId { get; set; }
        public bool Status { get; set; }
        public virtual Product Product { get; set; }
    }
}
