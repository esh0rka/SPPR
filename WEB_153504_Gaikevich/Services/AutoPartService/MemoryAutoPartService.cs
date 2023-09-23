//using System;
//using System.Diagnostics;
//using WEB_153504_Gaikevich.Domain.Entities;
//using WEB_153504_Gaikevich.Domain.Models;
//using WEB_153504_Gaikevich.Services.CategoryService;
//using Microsoft.AspNetCore.Mvc;

//namespace WEB_153504_Gaikevich.Services.AutoPartService
//{
//	public class MemoryAutoPartService : IAutoPartService
//    {
//        private readonly IConfiguration _config;
//        List<AutoPart> _autoParts;
//        List<Category> _categories;

//        public MemoryAutoPartService([FromServices] IConfiguration config, ICategoryService categoryService)
//		{
//            _config = config;
//            _categories = categoryService.GetCategoryListAsync().Result.Data;
//            SetupData();
//		}

//        public Task<ResponseData<AutoPart>> CreateProductAsync(AutoPart product, IFormFile? formFile)
//        {
//            throw new NotImplementedException();
//        }

//        public Task DeleteProductAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ResponseData<AutoPart>> GetProductByIdAsync(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public Task<ResponseData<ListModel<AutoPart>>> GetProductListAsync(string? categoryNormalizedName, int pageNo = 1)
//        {
//            try
//            {
//                var filteredAutoParts = string.IsNullOrEmpty(categoryNormalizedName)
//                    ? _autoParts
//                    : _autoParts.Where(p => p.Category?.NormalizedName == categoryNormalizedName).ToList();

//                int pageSize = int.Parse(_config["AppSettings:PageSize"]);
//                int totalCount = filteredAutoParts.Count;
//                int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
//                int startIndex = (pageNo - 1) * pageSize;

//                var itemsOnPage = filteredAutoParts.Skip(startIndex).Take(pageSize).ToList();

//                var listModel = new ListModel<AutoPart>
//                {
//                    Items = itemsOnPage,
//                    CurrentPage = pageNo,
//                    TotalPages = totalPages
//                };

//                var responseData = new ResponseData<ListModel<AutoPart>>
//                {
//                    Data = listModel,
//                    Success = true
//                };

//                return Task.FromResult(responseData);
//            }
//            catch (Exception ex)
//            {
//                var responseData = new ResponseData<ListModel<AutoPart>>
//                {
//                    Success = false,
//                    ErrorMessage = ex.Message
//                };

//                return Task.FromResult(responseData);
//            }
//        }

//        public Task UpdateProductAsync(int id, AutoPart product, IFormFile? formFile)
//        {
//            throw new NotImplementedException();
//        }

//        private void SetupData()
//        {
//            _autoParts = new List<AutoPart>
//            {
//                new AutoPart
//                {
//                    Id = 1,
//                    Name = "Tigar Winter 1",
//                    Description = "Шины Tigar Winter 1 могут использоваться практически на всех " +
//                    "легковых автомобилях — от компактных городских бюджетников до вместительных" +
//                    " семейных минивэнов, мощных кроссоверов и внедорожников. Модель является" +
//                    " нешипованной, но хорошо адаптирована для морозной погоды и обильных снегопадов," +
//                    " характерных для североевропейских, российских и скандинавских зим.",
//                    Price = 152.4M,
//                    Image = "Images/Catalog/tigar-winter-1.jpg",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("shiny-i-diski"))
//                },
//                new AutoPart
//                {
//                    Id = 2,
//                    Name = "Дверь задняя ВАЗ 1118, 1119, 2190 левая",
//                    Description = "Дверь ВАЗ-1118/2190 задняя левая с брусом безопасности и прокладкой изоляционной (катафорез - грунтованная под окраску).",
//                    Price = 260M,
//                    Image = "Images/Catalog/dver-zadnyaya-vaz.jpg",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("kuzov"))
//                },
//                new AutoPart
//                {
//                    Id = 3,
//                    Name = "Лобовое стекло ВАЗ 2101-2107",
//                    Description = "Оригинал. Автостекло лобовое ВАЗ 2101-2107, 4500ACLBL, 1970-2012, WS2101CB, ОРИГИНАЛ 2101-5206010, БОР.",
//                    Price = 141.9M,
//                    Image = "Images/Catalog/lobovoe.png",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("styokla"))
//                },
//                new AutoPart
//                {
//                    Id = 4,
//                    Name = "Аккумулятор Varta Blue Dynamic D24",
//                    Description = "Аккумулятор Varta Blue Dynamic D24 (60 А/h), 540А R+ (560 408 054).",
//                    Price = 244M,
//                    Image = "Images/Catalog/akum1.webp",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("akkumulyatory"))
//                },
//                new AutoPart
//                {
//                    Id = 5,
//                    Name = "Аккумулятор Decus золото (66 Ah) L+",
//                    Description = "АКБ свинцово-кислотного типа марки Decus изготавливается на Елабужском заводе, соответствует высоким стандартам качества. Продукция предприятия сертифицирована по международному стандарту ISO 9001, что гарантирует надежность и безопасность эксплуатации.",
//                    Price = 266M,
//                    Image = "Images/Catalog/akum2.png",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("akkumulyatory"))
//                },
//                new AutoPart
//                {
//                    Id = 6,
//                    Name = "Аккумулятор E-lab+EFB (60 Ah) L+",
//                    Description = "Аккумулятор 6СТ-60 \"E-LAB + EFB\" предназначен для использования в автомобилях с повышенным энергопотреблением или с системой Start-Stop. При разработке этой модели инженеры учли особенности эксплуатации более 200 автомобилей и климатические условия России, страны-производителя. Таким образом, полученный продукт адаптирован к возможным изменениям температур и требованиям производителей автомобилей. Разработка основана на технологии \"Enhanced Flooded Battery\" (EFB), что является ключевой особенностью этого аккумулятора.",
//                    Price = 241M,
//                    Image = "Images/Catalog/akum3.jpg",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("akkumulyatory"))
//                },
//                new AutoPart
//                {
//                    Id = 7,
//                    Name = "Боковое стекло ВАЗ 2101-2107",
//                    Description = "Автостекло боковое ВАЗ 2101-2107, 4500FCLS4FD, 1970-2006, BO2101+TKRVC, ОРИГИНАЛ, БОР.",
//                    Price = 12M,
//                    Image = "Images/Catalog/bokovoe.jpg",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("styokla"))
//                },
//                new AutoPart
//                {
//                    Id = 8,
//                    Name = "Фильтр топливный ВАЗ 2101, 2108",
//                    Description = "Топливный фильтр для автомобилей ВАЗ с карбюраторным двигателем.",
//                    Price = 1.2M,
//                    Image = "Images/Catalog/filtr-toplivnyj.webp",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("toplivnaya-sistema"))
//                },
//                new AutoPart
//                {
//                    Id = 9,
//                    Name = "Амортизаторы Shtokauto газ -50 мм, задние, ВАЗ 2101-2107",
//                    Description = "Комплект задних газомасляных амортизаторов \"Shtokauto\" для автомобилей ВАЗ 2101, 2102, 2103, 2104, 2105, 2106, 2107 устанавливаются под укороченные пружины и имеют более жесткие характеристики, относительно стоковых амортизаторов.",
//                    Price = 140M,
//                    Image = "Images/Catalog/amort.jpg",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("podveska"))
//                },
//                new AutoPart
//                {
//                    Id = 10,
//                    Name = "Насос топливный, погружной 255 лит. час Walbro GSS342",
//                    Description = "Насос топливный погружного типа, производительность 255л/час. Подходит для установки в автомобили ВАЗ и иномарки. Диаметр корпуса 38мм, длина корпуса 76мм, входное сечение 7мм, выходное сечение 6мм. В комплект входит сетчатый фильтр, разъем для подключения, шланг с хомутами, защитный чехол, монтажный уплотнитель.",
//                    Price = 140M,
//                    Image = "Images/Catalog/nasos-top.jpg",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("toplivnaya-sistema"))
//                },
//                new AutoPart
//                {
//                    Id = 11,
//                    Name = "Подрамник с рычагами – ВАЗ 2108-21099, 2113-2115",
//                    Description = "Подрамник для автомобилей ВАЗ 2108, 2109, 21099, 2113, 2114, 2115 на резиновых сайлентблоках. Применение материала СТАЛЬ20 позволило получить высокопрочное изделие сравнительно небольшого веса.",
//                    Price = 120M,
//                    Image = "Images/Catalog/podramnik.jpg",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("podveska"))
//                },
//                new AutoPart
//                {
//                    Id = 12,
//                    Name = "IFREE Майами (Нео-классик) 5.5J R14 4x98 ET-24 DIA-58.6 ",
//                    Description = "Автомобильные диски iFree Майами (Нео-классик) реализованы в элегантном дизайне, являются конструктивно прочными.",
//                    Price = 152M,
//                    Image = "Images/Catalog/lite.jpg",
//                    Category = _categories.Find(c=>c.NormalizedName.Equals("shiny-i-diski"))
//                },
//            };
//        }
//    }
//}

