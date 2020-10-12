using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Common.Encryption;
using IdentityModel.Client;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models.Auth;

namespace WebApi.MidWares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class TokenIdentityMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenProviderOptions _options;
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;

        public TokenIdentityMiddleware(RequestDelegate next, IOptions<TokenProviderOptions> tokenOptions,
            IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _next = next;
            _options = tokenOptions.Value;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //string id_token = httpContext.Request.Headers["Authorization"];
            //string token = id_token.Replace("Bearer", "").Trim();
            //if (string.IsNullOrEmpty(token))
            //{

            //}
            ////解析Token
            //JwtSecurityToken jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
            ////验证有效期
            //string expTime = jwtToken.Claims.FirstOrDefault(claim => claim.Type == "exp").Value;
            //if (!string.IsNullOrEmpty(expTime))
            //{
            //    int expireTime = int.Parse(expTime);
            //    int now = (int)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds;
            //    //if (expireTime < now)
            //    //{
            //    //    throw new Exception(await Localization.Localizer.GetValueAsync("授權已超時，即將重新登錄"));
            //    //}
            //}
            ////验证来源
            //VerifyToken(id_token.Replace("Bearer", "").Trim());
            // request token
            //var client = _httpClientFactory.CreateClient();
            //var disco = client.GetDiscoveryDocumentAsync(_configuration.GetSection("ADFS:ADFSDiscoveryDoc").Value).Result;
            //if (disco.IsError)
            //{
            //    Console.WriteLine(disco.Error);
            //    throw new Exception(await Localization.Localizer.GetValueAsync("授權失敗，請重新登入"));
            //}
            //var tokenResponse = await client.RequestAuthorizationCodeTokenAsync(new AuthorizationCodeTokenRequest()
            //{
            //    Address = disco.TokenEndpoint,
            //    ClientId = _configuration.GetSection("ADFS:ClientId").Value,
            //    //客户端密码
            //    ClientSecret = _configuration.GetSection("ADFS:ClientSecret").Value,
            //    Code = httpContext.Request.Headers["AuthorizationCode"],
            //    RedirectUri = _configuration.GetSection("ADFS:RedirectUri").Value,
            //    GrantType = GrantType.AuthorizationCode               
            //});
            //if (tokenResponse.IsError)
            //{
            //    throw new Exception(await Localization.Localizer.GetValueAsync("授權失敗，請重新登入"));
            //}
            await _next(httpContext);
        }

        private bool VerifyToken(string jwt)
        {
            return true;
        }
    }



    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class TokenIdentityMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenIdentityMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TokenIdentityMiddleware>();
        }
    }
}
