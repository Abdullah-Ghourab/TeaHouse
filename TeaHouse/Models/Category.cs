﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TeaHouse.Models
{
    public class Category:BaseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}