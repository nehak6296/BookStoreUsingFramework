using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{    
    public class Customer
    {
        [Key]
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int PhoneNumber { get; set; }
        [Required]
        public string Address { get; set; }
        public string Locality { get; set; }
        public string Landmark { get; set; }
        [Required]
        public int Pincode { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
