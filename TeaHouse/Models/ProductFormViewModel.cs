using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeaHouse.Models
{
    public class ProductFormViewModel 

    {
        public int? Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public string Image { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}