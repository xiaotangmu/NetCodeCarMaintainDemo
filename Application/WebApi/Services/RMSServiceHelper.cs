namespace WebApi.Services
{
    public class RMSServiceHelper
    {
        //private readonly IConfiguration _configuration;
        //private readonly IHttpClientFactory _httpClientFactory;

        //public RMSServiceHelper(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        //{
        //    _configuration = configuration;
        //    _httpClientFactory = httpClientFactory;
        //}

        //public async Task<bool> IsFeeByNewStudent(string applicationCode)
        //{
        //    Uri clientUri = new Uri(string.Format("{0}{1}?applicationCode={2}",
        //  _configuration.GetSection("RMS:BaseUrl").Value,
        //  _configuration.GetSection("RMS:IsFeeByNewStudent").Value, applicationCode));
        //    return await IsFee(clientUri);
        //}

        //public async Task<bool> IsFeeByOldStudent(string studentCode)
        //{
        //    Uri clientUri = new Uri(string.Format("{0}{1}?studentCode={2}",
        //  _configuration.GetSection("RMS:BaseUrl").Value,
        //  _configuration.GetSection("RMS:IsFeeByOldStudent").Value, studentCode));
        //    return await IsFee(clientUri);
        //}

        //private async Task<bool> IsFee(Uri clientUri)
        //{
        //    if (clientUri == null)
        //    {
        //        return false;
        //    }
        //    var content = new StringContent("", Encoding.UTF8, "application/json");
        //    var client = _httpClientFactory.CreateClient();
        //    client.BaseAddress = clientUri;
        //    try
        //    {
        //        var response = await client.GetAsync(client.BaseAddress);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var data = await response.Content.ReadAsStringAsync();
        //            RequestResponse<bool> result = JsonConvert.DeserializeObject<RequestResponse<bool>>(data);
        //            return result.data;
        //        }
        //    }
        //    catch (TimeoutException timeOutException)
        //    {
        //        throw new Exception(await Localization.Localizer.GetValueAsync("TimeOut"));
        //    }
        //    catch (HttpRequestException ex)
        //    {
        //        throw new Exception("RMS服務未啓動");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        client.Dispose();
        //    }
        //    return false;
        //}
    }
}
