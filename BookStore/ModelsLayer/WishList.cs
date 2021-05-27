using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer
{
    public class WishList
    {
        [Key]
        public int WishListId { get; set; }
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int WishListQuantity { get; set; }
    }
}
