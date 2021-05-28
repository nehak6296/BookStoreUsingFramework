using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IOrdersRepo
    {
        int PlaceOrder(int userId, int cartId);
    }
}
