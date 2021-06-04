using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class Orders
    {
        [Key]
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CartId { get; set; }
    }
}
