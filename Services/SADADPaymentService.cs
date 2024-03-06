using Automation_System.Entities;
using RestSharp;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Automation_System.Interfaces;
using Microsoft.AspNetCore.Http.Metadata;
using Azure.Core;
using System.Web;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Reflection.Metadata;
using Azure;
using Automation_System.Entities.WhatsappEntity;
using System.Net.Http.Headers;

namespace Automation_System.Services
{
    public class SADADPaymentService: ISadadServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly ILogger<SADADPaymentService> _logger;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;

        public SADADPaymentService(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<SADADPaymentService> logger, HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            _logger = logger;
            _httpClient = httpClient;
            _memoryCache = memoryCache?? throw new ArgumentNullException(nameof(memoryCache));            
        }

        //method to generate access token
        public  async Task <string> GenerateAccessToken()
        {

            // Retrieve SADAD credentials from appsettings.json
            var apiKey = _configuration["SADADConfig:ApiKey"];
            var username = _configuration["SADADConfig:Username"];
            var password = _configuration["SADADConfig:Password"];
            var apiUrl = _configuration["SADADConfig:apiUrl"];
            string RefreshToken = _configuration["SADADConfig:RefreshToken"];

            // SADAD GenerateAccessToken API endpoint URL
      
            // Create an HttpClient
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                // Prepare the authentication header
                //httpClient.DefaultRequestHeaders.Add("Authorization", $"Basic {Convert.ToBase64String(Encoding.ASCII.GetBytes($"{username}:{password}"))}");
                httpClient.DefaultRequestHeaders.Add("Authorization", RefreshToken);

                // Make the POST request to the SADAD GenerateAccessToken API
                var response =await httpClient.PostAsync(apiUrl, null);

                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response to obtain the access token
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var accessTokenResponse = JsonSerializer.Deserialize<AccessTokenResponse>(responseContent);

                    return accessTokenResponse.response.accessToken;                    
                }
                else
                {
                    throw new InvalidOperationException("Failed to insert the invoice. Check the request data or try again later.");
                }
            }
        }

        //method to Post Invoice To Sadad System
        public async Task<InvoiceInsertResponse> InsertInvoice(InvoiceInsertRequest request)
        {
            // SADAD API endpoint URL for inserting an invoice
            //string accessToken = await GenerateAccessToken(); To use access Token without in memory caching

            string cacheKey = $"UniqueKeyForYourApiMethod_{request}";

            if (!_memoryCache.TryGetValue<string>(cacheKey, out var accessToken))
            {
                accessToken = await GenerateAccessToken(); // Run method to retrieve the value

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                _memoryCache.Set(cacheKey, accessToken, cacheEntryOptions);
            }

            var apiUrl2 = _configuration["SADADConfig:apiUrl2"];
            // Create an HttpClient
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                // Set the access token in the Authorization header
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                // Serialize the invoice request data to JSON
                var payload = JsonSerializer.Serialize(request);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");

                // Make the POST request to the SADAD API
                var response = await httpClient.PostAsync(apiUrl2, content);

                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response JSON to an InvoiceInsertResponse object
                    var responseContent = await response.Content.ReadAsStringAsync();

                    var invoiceInsertResponse = JsonSerializer.Deserialize<InvoiceInsertResponse>(responseContent);

                    //return invoiceInsertResponse;

                    return invoiceInsertResponse;
                }
                else
                {
                    throw new InvalidOperationException("Failed to insert the invoice. Check the request data or try again later.");
                }
            }
        }

        //service to get invoice by id
        public async Task<InvoiceResponseData> GetInvoiceByIdAsync(string InvoiceId)
        {
            var apiUrl3 = _configuration["SADADConfig:apiUrl3"];
            //string accessToken = await GenerateAccessToken(); To use access Token without in memory caching
            string cacheKey = $"UniqueKeyForYourApiMethod_{InvoiceId}";

            if (!_memoryCache.TryGetValue<string>(cacheKey, out var accessToken))
            {
                accessToken = await GenerateAccessToken(); // Run method to retrieve the value

                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                };

                _memoryCache.Set(cacheKey, accessToken, cacheEntryOptions);
            }

            // Create an HttpClient
            using (var httpClient = _httpClientFactory.CreateClient())
            {
                // Set the access token in the Authorization header
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                // Make the POST request to the SADAD API
                               
                var builder = new UriBuilder(apiUrl3);
                //builder.Port = -1; Should be -1 to make no port in the link
                builder.Port = -1;
                var query = HttpUtility.ParseQueryString(builder.Query);               
                query["id"] = InvoiceId;                
                builder.Query = query.ToString();
                string url = builder.ToString();

                var response = await httpClient.GetAsync(url);
                //var resp = await httpClient.GetAsync(apiUrl3 + "?id=" + InvoiceId);
                // Handle the response
                if (response.IsSuccessStatusCode)
                {
                    // Deserialize the response JSON to an InvoiceInsertResponse object
                    var responseContent = await response.Content.ReadAsStringAsync();


                    var invoiceInsertResponse = JsonSerializer.Deserialize<InvoiceResponseData>(responseContent);
                    return invoiceInsertResponse;
                }
                else
                {
                    throw new InvalidOperationException("Failed to Get the invoice. Check the request data or try again later.");
                }
            }
        }



        public async Task<MessageResponse> SendWhatsappMessage(WhatsappRequest data)
        {
            var ApiToken = _configuration["WhatsappSettings:Token"];
            var ApiUrl = _configuration["WhatsappSettings:ApiUrl"];
            //var language = Request.Headers["language"].ToString();
            using HttpClient httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("apikey", ApiToken);
            httpClient.DefaultRequestHeaders.Add("apikey", ApiToken);

            HttpResponseMessage response = await httpClient.PostAsJsonAsync(new Uri(ApiUrl), data);
            if (response.IsSuccessStatusCode)
            {
                

                var responseContent = await response.Content.ReadAsStringAsync();


                var invoiceInsertResponse = JsonSerializer.Deserialize<MessageResponse>(responseContent);
                return invoiceInsertResponse;
            }
            else
            {
                throw new Exception("Some Thing went wrong");
            }
        }


    }
}



