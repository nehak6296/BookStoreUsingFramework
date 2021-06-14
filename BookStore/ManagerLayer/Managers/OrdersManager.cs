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
    public class OrdersManager : IOrdersManager
    {
        private readonly IOrdersRepo ordersRepo;
        public OrdersManager(IOrdersRepo ordersRepo)
        {
            this.ordersRepo = ordersRepo;
        }
        public Orders PlaceOrder(Orders orders)
        {
            return this.ordersRepo.PlaceOrder(orders);
        }
        public Orders GetAllOrders(Orders orders)
        {
            return this.ordersRepo.GetAllOrders(orders);
        }
    }
}
