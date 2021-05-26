using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface ICartRepo
    {
        Cart AddToCart(Cart cartModel);
        bool RemoveFromCart(int cartId);

    }
}
