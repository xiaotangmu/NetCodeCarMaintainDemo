using System;
using System.Threading.Tasks;
using DataModel.System;
using Microsoft.Extensions.Configuration;
using WebApi.Models.Auth;

namespace WebApi.Utils.TokenManagement
{
    public class TokenManager : ITokenManager
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenContainer _container;
        private readonly ITokenProvider _tokenProvider;

        private const string _accessTokenKey = "access_token_";

        private const string _refreshTokenKey = "refresh_token_";

        public TokenManager(IConfiguration configuration, ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
            _configuration = configuration;
            IConfigurationSection cacheSection = _configuration.GetSection("Cache");
            if (cacheSection["Type"].Equals("redis"))
            {
                var redisOptions = new RedisOptions
                {
                    Host = _configuration.GetSection("Cache").GetSection("Redis")["host"],
                    Port = _configuration.GetSection("Cache").GetSection("Redis")["port"]
                };
                _container = new RedisCacheManager(redisOptions);
            }
            else if (cacheSection["Type"].Equals("local"))
            {
                _container = new LocalCacheManager();
            }
        }

        public async Task<Token> GenerateToken(AccountLoginModel accountModel)
        {
            Token token = await _tokenProvider.Generate(accountModel);
            if (!RecordToken(accountModel, token) || string.IsNullOrEmpty(token.access_token))
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("Token授權失敗，請重試"));
            }
            return token;
        }

        /// <summary>
        /// 验证Token的时效性
        /// </summary>
        /// <param name="userInfo">当前登录用户</param>
        /// <returns>
        /// 如果access_token有效，则返回空值；
        /// 如果access_token无效，但refresh_token有效，则生成新的access_token和refresh_token，并返回access_token
        /// 如果access_token无效，且refresh_token无效，则抛出Token失效异常；
        /// </returns>
        public async Task<string> ValidToken(CurrentUserInfo userInfo)
        {
            //return string.Empty;//暂时不验证Token
            //验证Access_Token有效性
            if (IsExistAccessToken(userInfo.Account))
            {
                //有效则返回空值
                return null;
            }
            //access_token失效后，再验证RefreshToken有效性，有效则刷新token返回
            if (IsExistRefreshToken(userInfo.Account))
            {
                AccountLoginModel account = GetCacheAccount(userInfo.Account);
                Token refreshToken = await _tokenProvider.Generate(account);
                RecordToken(account, refreshToken);
                return refreshToken.access_token;
            }
            //都验证失效，则抛出Token过期异常
            throw new TokenExpiredException(await Localization.Localizer.GetValueAsync("Expire"));
        }

        public void RemoveToken(string account)
        {
            if (IsExistAccessToken(account))
            {
                _container.Remove(_accessTokenKey + account);
            }
            if (IsExistRefreshToken(account))
            {
                _container.Remove(_refreshTokenKey + account);
            }
        }

        /// <summary>
        /// AccessToken是否存在（过期）
        /// </summary>
        private bool IsExistAccessToken(string account)
        {
            if (_container == null)
            {
                return false;
            }
            return _container.IsExist(_accessTokenKey + account);
        }

        /// <summary>
        /// RefreshToken是否存在（过期）
        /// </summary>
        private bool IsExistRefreshToken(string account)
        {
            if (_container == null)
            {
                return false;
            }
            return _container.IsExist(_refreshTokenKey + account);
        }

        private bool RecordToken(AccountLoginModel accountModel, Token token)
        {
            if (_container == null)
            {
                return false;
            }
            if (IsExistAccessToken(accountModel.Account))
            {
                _container.Remove(_accessTokenKey + accountModel.Account);
            }
            if (IsExistRefreshToken(accountModel.Account))
            {
                _container.Remove(_refreshTokenKey + accountModel.Account);
            }
            bool isSuccess = _container.Push(_accessTokenKey + accountModel.Account, token.access_token, new TimeSpan(0, 0, token.expires_in));
            if (isSuccess)
            {
                isSuccess = _container.Push(_refreshTokenKey + accountModel.Account, token.reflesh_token, new TimeSpan(0, 0, (token.re_expires)));
                //將密碼也儲存，當需重新獲取AccessToken時，不需用戶重複輸入密碼，過期與refresh_token一致
                if (isSuccess)
                {
                    isSuccess = _container.Push(accountModel.Account, accountModel.Password, new TimeSpan(0, 0, (token.re_expires)));
                }
            }
            return isSuccess;
        }

        private AccountLoginModel GetCacheAccount(string account)
        {
            if (_container == null)
            {
                return new AccountLoginModel();
            }
            string password = _container.GetValue(account);
            return new AccountLoginModel
            {
                Account = account,
                Password = password
            };
        }

        private string GetAccessToken(string loginName)
        {
            if (_container == null)
            {
                return string.Empty;
            }
            return _container.GetValue(_accessTokenKey + loginName);
        }

        private string GetRefreshToken(string loginName)
        {
            if (_container == null)
            {
                return string.Empty;
            }
            return _container.GetValue(_refreshTokenKey + loginName);
        }
    }
}
