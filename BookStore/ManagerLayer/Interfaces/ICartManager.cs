using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface ICartManager
    {
        Cart AddToCart(Cart cartModel);
        bool RemoveFromCart(int cartId,int userId);
        List<GetCart> GetCart();

    }
}
