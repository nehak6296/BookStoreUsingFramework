using ManagerLayer.Interfaces;
using ManagerLayer.Managers;
using RepositoryLayer.Interfaces;
using RepositoryLayer.Repositories;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BookStore
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IBookManager, BookManager>();
            container.RegisterType<ICartManager, CartManager>();
            container.RegisterType<ICustomerManager, CustomerManager>();
            container.RegisterType<IOrdersManager, OrdersManager>();
            container.RegisterType<IUserManager, UserManager>();
            container.RegisterType<IWishListManager, WishListManager>();
            container.RegisterType<IBookRepo, BookRepo>();
            container.RegisterType<ICartRepo, CartRepo>();
            container.RegisterType<ICustomerRepo, CustomerRepo>();
            container.RegisterType<IOrdersRepo, OrdersRepo>();
            container.RegisterType<IUserRepo, UserRepo>();
            container.RegisterType<IWishListRepo, WishListRepo>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}