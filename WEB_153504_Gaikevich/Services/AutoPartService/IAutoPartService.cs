using System;
using WEB_153504_Gaikevich.Domain.Models;
using WEB_153504_Gaikevich.Domain.Entities;

namespace WEB_153504_Gaikevich.Services.AutoPartService
{
    public interface IAutoPartService
    {
        public Task<ResponseData<ListModel<AutoPart>>> GetProductListAsync(string?
        categoryNormalizedName, int pageNo = 1);
        public Task<ResponseData<AutoPart>> GetProductByIdAsync(int id);
        public Task UpdateProductAsync(int id, AutoPart product, IFormFile? formFile);
        public Task DeleteProductAsync(int id);
        public Task<ResponseData<AutoPart>> CreateProductAsync(AutoPart product, IFormFile? formFile);
    }
}
