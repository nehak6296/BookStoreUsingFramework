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
    public class UserManager : IUserManager
    {
        private readonly IUserRepo userRepo;

        public UserManager(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        public bool LoginUser(Login loginModel)
        {
            return this.userRepo.LoginUser(loginModel);
        }

        public Registration RegisterUser(Registration registrationModel)
        {
            return this.userRepo.RegisterUser(registrationModel);
        }

    }
}
