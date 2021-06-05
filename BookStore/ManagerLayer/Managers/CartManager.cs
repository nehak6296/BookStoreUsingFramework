using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class CartManager : ICartManager
    {
        private readonly ICartRepo cartRepo = new CartRepo();
        //public CartManager(ICartRepo cartRepo)
        //{
        //    this.cartRepo = cartRepo;
        //}
        public Cart AddToCart(Cart cartModel)
        {
            return this.cartRepo.AddToCart(cartModel);
        }

        public List<GetCart> GetCart()
        {
            return this.cartRepo.GetCart();
        }

        public bool RemoveFromCart(int cartId, int userId)
        {
            return this.cartRepo.RemoveFromCart(cartId,userId);
        }

    }
}
