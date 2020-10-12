namespace WebApi.Services
{
    public class DPSIServiceHelper
    {
        //private readonly IConfiguration _configuration;
        //private readonly IHttpClientFactory _httpClientFactory;

        //public DPSIServiceHelper(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        //{
        //    _configuration = configuration;
        //    _httpClientFactory = httpClientFactory;
        //}

        //public async Task<StudentBaseInfoViewModel> GetNewStudentInfo(QuickLoginModel loginModel)
        //{
        //    Uri clientUri = new Uri(string.Format("{0}{1}?applicationCode={2}&idNo={3}",
        //              _configuration.GetSection("DPSI:BaseUrl").Value,
        //              _configuration.GetSection("DPSI:GetNewStudentInfoApi").Value,
        //              loginModel.ApplicationCode, loginModel.IdCard));
        //    return await GetStudentInfo(clientUri);
        //}

        //public async Task<StudentBaseInfoViewModel> GetOldStudentInfo(string account)
        //{
        //    Uri clientUri = new Uri(string.Format("{0}{1}?account={2}",
        //            _configuration.GetSection("DPSI:BaseUrl").Value,
        //            _configuration.GetSection("DPSI:GetOldStudentInfoApi").Value,
        //            account));
        //    return await GetStudentInfo(clientUri);
        //}

        //private async Task<StudentBaseInfoViewModel> GetStudentInfo(Uri clientUri)
        //{
        //    if (clientUri == null)
        //    {
        //        return new StudentBaseInfoViewModel();
        //    }
        //    var content = new StringContent("", Encoding.UTF8, "application/json");
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = clientUri;
        //    try
        //    {
        //        var response = await client.GetAsync(client.BaseAddress);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();
        //            RequestResponse<StudentBaseInfoViewModel> addressResult = JsonConvert.DeserializeObject<RequestResponse<StudentBaseInfoViewModel>>(result);
        //            return addressResult.data;
        //        }
        //    }
        //    catch (TimeoutException timeOutException)
        //    {
        //        throw new Exception(await Localization.Localizer.GetValueAsync("TimeOut"));
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw new Exception("DPSI服務未啓動");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        client.Dispose();
        //    }
        //    return null;
        //}

        //public static CurrentUserInfo ValidateNewStudentIdentity(QuickLoginModel loginModel)
        //{
        //    //先从数据库中验证，如果不存在再更新DPSI数据，还是不存在则返回提示
        //    return new CurrentUserInfo
        //    {
        //        Name = "測試",
        //        Account = loginModel.ApplicationCode,
        //        UserType = UserType.VISITOR
        //    };
        //}
    }
}
