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
        public int CustomerId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string Landmark { get; set; }
        public int Pincode { get; set; }
        public string City { get; set; }
        public string Type { get; set; }
    }
}
