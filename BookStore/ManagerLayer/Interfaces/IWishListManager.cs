using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface IWishListManager
    {
        WishList AddToWishList(WishList wishList);
        int RemoveFromWishList(int WishListId);
        List<GetWishList> GetWishList();
    }
}
