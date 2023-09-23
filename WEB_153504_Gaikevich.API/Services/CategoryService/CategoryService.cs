using System;
using Microsoft.AspNetCore.Mvc;
using WEB_153504_Gaikevich.Domain.Entities;
using WEB_153504_Gaikevich.Domain.Models;
using WEB_153504_Gaikevich.API.Data;
using Microsoft.EntityFrameworkCore;

namespace WEB_153504_Gaikevich.API.Services
{
	public class CategoryService : ICategoryService
	{
        readonly AppDbContext _context;

		public CategoryService(AppDbContext context)
		{
            _context = context;
        }

        public Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            var result = new ResponseData<List<Category>>();
            List<Category> categoryList = _context.Category.ToList();
            result.Data = categoryList;

            return Task.FromResult(result);
        }
    }
}

