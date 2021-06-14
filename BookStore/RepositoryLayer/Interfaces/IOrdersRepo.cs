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
        Orders PlaceOrder(Orders orders);
        Orders GetAllOrders(Orders orders);
    }
}
