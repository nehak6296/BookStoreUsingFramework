using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IWishListRepo
    {
        WishList AddToWishList(WishList wishList);
        int RemoveFromWishList(int userId, int wishListId);
    }
}
