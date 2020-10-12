using DataModel.System;
using IdentityModel.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models.Auth;

namespace WebApi.Utils.TokenManagement
{
    /// <summary>
    /// token生成类
    /// </summary>
    public class TokenProvider : ITokenProvider
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly TokenProviderOptions _tokenProviderOptions;

        public TokenProvider(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            _tokenProviderOptions = BuildTokenOptions(_configuration);
        }

        private TokenProviderOptions BuildTokenOptions(IConfiguration configuration)
        {
            return new TokenProviderOptions
            {
                Audience = configuration.GetSection("Jwt:Audience").Value,
                Issuer = configuration.GetSection("Jwt:Issuer").Value,
                SecretKey = configuration.GetSection("Jwt:SecretKey").Value,
                Expiration = int.Parse(configuration.GetSection("Jwt:Expiration").Value),
                ReExpiration = int.Parse(configuration.GetSection("Jwt:ReExpiration").Value)
            };
        }

        public async Task<Token> Generate(AccountLoginModel account)
        {
            // request token
            var client = _httpClientFactory.CreateClient();
            var disco = client.GetDiscoveryDocumentAsync(_configuration.GetSection("ADFS:ADFSDiscoveryDoc").Value).Result;
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                throw new Exception(await Localization.Localizer.GetValueAsync("授權失敗，請重新登入"));
            }
            var tokenResponse = await client.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest()
            {
                Address = disco.TokenEndpoint,
                ClientId = _configuration.GetSection("ADFS:ClientId").Value,
                //客户端密码
                ClientSecret = _configuration.GetSection("ADFS:ClientSecret").Value,
                Code = account.IdentitytCode,
                RedirectUri = _configuration.GetSection("ADFS:RedirectUri").Value
            });
            if (tokenResponse.IsError)
            {
                throw new Exception(await Localization.Localizer.GetValueAsync("授權失敗，請重新登入"));
            }
            Token token = new Token();
            token.access_token = tokenResponse.AccessToken;
            token.expires_in = tokenResponse.ExpiresIn;
            token.reflesh_token = tokenResponse.RefreshToken;
            token.re_expires = _tokenProviderOptions.ReExpiration;
            return token;

        }

        private long ToUnixEpochDate(DateTime date)
        {
            return (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
        }
    }
}
