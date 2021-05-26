using ModelsLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRepo
    {
        Registration RegisterUser(Registration registrationModel);
        bool LoginUser(Login loginModel);
    }
}
