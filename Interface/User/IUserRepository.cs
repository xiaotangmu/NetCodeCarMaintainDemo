using DateModel.Sku;
using DateModel.User;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Common;
using ViewModel.Sku;
using ViewModel.User;

namespace Interface.Sku
{
    public interface IUserRepository : IBaseRepository
    {
        Task<bool> IsExistUserName(string userName);
        Task<bool> IsExistUserByNameAndPwd(UserAddModel model);
        Task<string> Insert(UMS_USER entity);
    }
}
