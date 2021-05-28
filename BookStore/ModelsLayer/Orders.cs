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
        public int OderId { get; set; }
        public int UserId { get; set; }
        public int CartId { get; set; }
    }
}
