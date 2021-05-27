using ManagerLayer.Interfaces;
using ModelsLayer;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Managers
{
    public class WishListManager : IWishListManager
    {
        private readonly IWishListRepo wishListRepo;
        public WishList AddToWishList(WishList wishList)
        {
            throw new NotImplementedException();
        }
    }
}
