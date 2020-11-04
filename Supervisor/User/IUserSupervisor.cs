using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel.User;

namespace Supervisor.User
{
    public interface IUserSupervisor
    {
        Task<bool> Login(UserAddModel model);
        Task<string> Register(UserAddModel model);
    }
}
