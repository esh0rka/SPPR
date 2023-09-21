using System;
using WEB_153504_Gaikevich.Domain.Entities;
using WEB_153504_Gaikevich.Domain.Models;

namespace WEB_153504_Gaikevich.Services.CategoryService
{
	public class MemoryCategoryService : ICategoryService
	{
        public Task<ResponseData<List<Category>>> GetCategoryListAsync()
        {
            var categories = new List<Category>
            {
                new Category {Id=1, Name="Шины и диски",
                NormalizedName="shiny-i-diski"},
                new Category {Id=2, Name="Аккумуляторы",
                NormalizedName="akkumulyatory"},
                new Category {Id=3, Name="Топливная система",
                NormalizedName="toplivnaya-sistema"},
                new Category {Id=4, Name="Подвеска",
                NormalizedName="podveska"},
                new Category {Id=5, Name="Стёкла",
                NormalizedName="styokla"},
                new Category {Id=6, Name="Кузов",
                NormalizedName="kuzov"},
            };
            var result = new ResponseData<List<Category>>();
            result.Data = categories;
            return Task.FromResult(result);
        }
    }
}

