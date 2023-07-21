using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeaHouse.Models
{
    public class BaseModel
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastUpdatedOn { get; set;}

    }
}
 