using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeaHouse.Models
{
    public class CategoryFormViewModel
    {
        
        public int? Id { get; set; }
        [Required,MaxLength(100,ErrorMessage ="Title Length must be less than 100")]
        public string Title { get; set; }
    }
}