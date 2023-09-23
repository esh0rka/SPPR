using System;
using System.Linq;
using WEB_153504_Gaikevich.API.Data;
using WEB_153504_Gaikevich.Domain.Entities;
using WEB_153504_Gaikevich.Domain.Models;

namespace WEB_153504_Gaikevich.API.Services
{
	public class AutoPartService : IAutoPartService
	{
        private readonly int _maxPageSize = 20;
        private List<Category>? _categories;
        private ICategoryService _categoryService;

        readonly AppDbContext _context;

        public AutoPartService(AppDbContext context, ICategoryService categoryService)
		{
            _context = context;
            _categoryService = categoryService;
            _categories = _categoryService.GetCategoryListAsync().Result.Data;
        }

        public Task<ResponseData<AutoPart>> CreateProductAsync(AutoPart product)
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

        public Task<ResponseData<ListModel<AutoPart>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1, int pageSize = 3)
        {
            ResizePageSize(ref pageSize);

            try
            {
                var categoryId = string.IsNullOrEmpty(categoryNormalizedName)
                    ? null
                    : _categories?.FirstOrDefault(c => c.NormalizedName == categoryNormalizedName)?.Id;
                var filteredAutoParts = string.IsNullOrEmpty(categoryNormalizedName)
                    ? _context.AutoPart.ToList()
                    : _context.AutoPart.Where(entity => entity.CategoryId == categoryId).ToList();

                int totalCount = filteredAutoParts.Count;
                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                if (pageNo < 1 || pageNo > totalPages)
                {
                    throw new ArgumentOutOfRangeException(nameof(pageNo), "Номер страницы находится вне допустимого диапазона.");
                }

                int startIndex = (pageNo - 1) * pageSize;

                var itemsOnPage = filteredAutoParts.Skip(startIndex).Take(pageSize).ToList();

                var listModel = new ListModel<AutoPart>
                {
                    Items = itemsOnPage,
                    CurrentPage = pageNo,
                    TotalPages = totalPages
                };

                var responseData = new ResponseData<ListModel<AutoPart>>
                {
                    Data = listModel,
                    Success = true
                };

                return Task.FromResult(responseData);
            }
            catch (Exception)
            {
                var responseData = new ResponseData<ListModel<AutoPart>>
                {
                    Success = false,
                    ErrorMessage = "Номер страницы находится вне допустимого диапазона."
                };

                return Task.FromResult(responseData);
            }
        }

        public Task<ResponseData<string>> SaveImageAsync(int id, IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        public Task UpdateProductAsync(int id, AutoPart product)
        {
            throw new NotImplementedException();
        }

        private void ResizePageSize(ref int pageSize)
        {
            pageSize = pageSize > _maxPageSize ? _maxPageSize : pageSize;
        }
    }
}

