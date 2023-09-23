using System;
using WEB_153504_Gaikevich.Domain.Models;
using WEB_153504_Gaikevich.Domain.Entities;

namespace WEB_153504_Gaikevich.API.Services
{
	public interface IAutoPartService
	{
        public Task<ResponseData<ListModel<AutoPart>>> GetProductListAsync( string? categoryNormalizedName, int pageNo = 1, int pageSize = 3);
        public Task<ResponseData<AutoPart>> GetProductByIdAsync(int id);
        public Task UpdateProductAsync(int id, AutoPart product);
        public Task DeleteProductAsync(int id);
        public Task<ResponseData<AutoPart>> CreateProductAsync(AutoPart product);
        public Task<ResponseData<string>> SaveImageAsync(int id, IFormFile formFile);
    }
}

