using System;
using System.Text;
using System.Text.Json;
using WEB_153504_Gaikevich.Domain.Entities;
using WEB_153504_Gaikevich.Domain.Models;

namespace WEB_153504_Gaikevich.Services.AutoPartService
{
	public class ApiAutoPartService : IAutoPartService
	{
        private readonly HttpClient _httpClient;
        private readonly string _pageSize;
        private readonly ILogger _logger;
        private readonly JsonSerializerOptions _serializerOptions;

        public ApiAutoPartService(HttpClient httpClient, IConfiguration configuration, ILogger<ApiAutoPartService> logger)
		{
            _httpClient = httpClient;
            _pageSize = configuration.GetSection("ItemsPerPage").Value ?? "3";
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
            _logger = logger;
        }

        public Task<ResponseData<AutoPart>> CreateProductAsync(AutoPart product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }

        public Task DeleteProductAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseData<AutoPart>> GetProductByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseData<ListModel<AutoPart>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
        {
            var urlString = new StringBuilder($"{_httpClient.BaseAddress?.AbsoluteUri}AutoParts/");

            if (categoryNormalizedName != null)
            {
                urlString.Append($"{categoryNormalizedName}/");
            };

            if (pageNo > 1)
            {
                urlString.Append($"page{pageNo}");
            };

            if (!_pageSize.Equals("3"))
            {
                urlString.Append(QueryString.Create("pageSize", _pageSize));
            }
            
            var response = await _httpClient.GetAsync(new Uri(urlString.ToString()));

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var responseData = await response.Content.ReadFromJsonAsync<ResponseData<ListModel<AutoPart>>>(_serializerOptions);

                    if (responseData != null)
                    {
                        return responseData;
                    }
                    else
                    {
                        _logger.LogError($"-----> Ошибка: Данные не удалось десериализовать.");
                        return new ResponseData<ListModel<AutoPart>>
                        {
                            Success = false,
                            ErrorMessage = $"Ошибка: Данные не удалось десериализовать."
                        };
                    }
                }
                catch (JsonException ex)
                {
                    _logger.LogError($"-----> Ошибка: {ex.Message}");
                    return new ResponseData<ListModel<AutoPart>>
                    {
                        Success = false,
                        ErrorMessage = $"Ошибка: {ex.Message}"
                    };
                }
            }
            else
            {
                _logger.LogError($"-----> Данные не получены от сервера. Error: { response.StatusCode}");
                return new ResponseData<ListModel<AutoPart>>
                {
                    Success = false,
                    ErrorMessage = $"Данные не получены от сервера. Error: { response.StatusCode}"
                };
            }
        }

        public Task UpdateProductAsync(int id, AutoPart product, IFormFile? formFile)
        {
            throw new NotImplementedException();
        }
    }
}

