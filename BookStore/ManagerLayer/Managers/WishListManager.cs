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
    public class WishListManager : IWishListManager
    {
        private readonly IWishListRepo wishListRepo;
        public WishListManager(IWishListRepo wishListRepo)
        {
            this.wishListRepo = wishListRepo;
        }
        public WishList AddToWishList(WishList wishList)
        {
            return this.wishListRepo.AddToWishList(wishList);
        }

        public List<GetWishList> GetWishList()
        {
            return this.wishListRepo.GetWishList();
        }

        public int RemoveFromWishList( int wishListId)
        {
            return this.wishListRepo.RemoveFromWishList( wishListId);

        }
    }
}
