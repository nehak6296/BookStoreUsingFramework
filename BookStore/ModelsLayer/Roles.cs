﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }        
    }
}
