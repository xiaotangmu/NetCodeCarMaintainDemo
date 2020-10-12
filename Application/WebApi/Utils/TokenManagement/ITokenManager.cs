using DataModel.System;
using System.Threading.Tasks;
using WebApi.Models.Auth;

namespace WebApi.Utils.TokenManagement
{
    public interface ITokenManager
    {
        Task<Token> GenerateToken(AccountLoginModel accountModel);
        void RemoveToken(string account);
        Task<string> ValidToken(CurrentUserInfo userInfo);
    }
}