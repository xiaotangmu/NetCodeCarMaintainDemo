using DataModel.System;
using System.Threading.Tasks;
using WebApi.Models.Auth;

namespace WebApi.Utils.TokenManagement
{
    public interface ITokenProvider
    {
        Task<Token> Generate(AccountLoginModel account);
    }
}