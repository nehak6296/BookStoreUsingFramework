using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerLayer.Interfaces
{
    public interface IOrdersManager
    {
        Orders PlaceOrder(Orders orders);
        Orders GetAllOrders(Orders orders);
    }
}
