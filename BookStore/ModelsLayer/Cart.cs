﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int CartBookQuantity { get; set; }
    }
}
