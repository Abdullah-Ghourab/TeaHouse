using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeaHouse.Models
{
    public class ProductViewModel:BaseModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}