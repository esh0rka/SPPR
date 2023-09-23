using System;
using WEB_153504_Gaikevich.Domain.Entities;
using WEB_153504_Gaikevich.Domain.Models;

namespace WEB_153504_Gaikevich.API.Services
{
	public interface ICategoryService
	{
        public Task<ResponseData<List<Category>>> GetCategoryListAsync();
    }
}

