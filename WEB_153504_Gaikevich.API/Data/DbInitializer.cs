using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WEB_153504_Gaikevich.Domain.Entities;

namespace WEB_153504_Gaikevich.API.Data
{
    public static class DbContextExtensions
    {
        public static void RemoveAll<T>(this DbContext context) where T : class
        {
            var dbSet = context.Set<T>();
            var allEntities = dbSet.ToList();
            dbSet.RemoveRange(allEntities);
        }
    }

    public class DbInitializer
	{
		public DbInitializer()
		{

		}

        public static async Task SeedData(WebApplication app)
		{
            using var scope = app.Services.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await context.Database.MigrateAsync();

            var categories = new List<Category>
            {
                new Category {Name="Шины и диски",
                NormalizedName="shiny-i-diski"},
                new Category {Name="Аккумуляторы",
                NormalizedName="akkumulyatory"},
                new Category {Name="Топливная система",
                NormalizedName="toplivnaya-sistema"},
                new Category {Name="Подвеска",
                NormalizedName="podveska"},
                new Category {Name="Стёкла",
                NormalizedName="styokla"},
                new Category {Name="Кузов",
                NormalizedName="kuzov"},
            };

            context.RemoveAll<Category>();

            await context.Category.AddRangeAsync(categories);

            context.SaveChanges();

            var urlHttps = app.Configuration.GetSection("AppSettings")["UrlHttps"];

            var autoParts = new List<AutoPart>
            {
                new AutoPart
                {
                    Name = "Tigar Winter 1",
                    Description = "Шины Tigar Winter 1 могут использоваться практически на всех " +
                    "легковых автомобилях — от компактных городских бюджетников до вместительных" +
                    " семейных минивэнов, мощных кроссоверов и внедорожников. Модель является" +
                    " нешипованной, но хорошо адаптирована для морозной погоды и обильных снегопадов," +
                    " характерных для североевропейских, российских и скандинавских зим.",
                    Price = 152.4M,
                    Image = urlHttps + "Images/Catalog/tigar-winter-1.jpg",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "shiny-i-diski")
                },
                new AutoPart
                {
                    Name = "Дверь задняя ВАЗ 1118, 1119, 2190 левая",
                    Description = "Дверь ВАЗ-1118/2190 задняя левая с брусом безопасности и прокладкой изоляционной (катафорез - грунтованная под окраску).",
                    Price = 260M,
                    Image = urlHttps + "Images/Catalog/dver-zadnyaya-vaz.jpg",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "kuzov")
                },
                new AutoPart
                {
                    Name = "Лобовое стекло ВАЗ 2101-2107",
                    Description = "Оригинал. Автостекло лобовое ВАЗ 2101-2107, 4500ACLBL, 1970-2012, WS2101CB, ОРИГИНАЛ 2101-5206010, БОР.",
                    Price = 141.9M,
                    Image = urlHttps + "Images/Catalog/lobovoe.png",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "styokla")
                },
                new AutoPart
                {
                    Name = "Аккумулятор Varta Blue Dynamic D24",
                    Description = "Аккумулятор Varta Blue Dynamic D24 (60 А/h), 540А R+ (560 408 054).",
                    Price = 244M,
                    Image = urlHttps + "Images/Catalog/akum1.webp",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "akkumulyatory")
                },
                new AutoPart
                {
                    Name = "Аккумулятор Decus золото (66 Ah) L+",
                    Description = "АКБ свинцово-кислотного типа марки Decus изготавливается на Елабужском заводе, соответствует высоким стандартам качества. Продукция предприятия сертифицирована по международному стандарту ISO 9001, что гарантирует надежность и безопасность эксплуатации.",
                    Price = 266M,
                    Image = urlHttps + "Images/Catalog/akum2.png",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "akkumulyatory")
                },
                new AutoPart
                {
                    Name = "Аккумулятор E-lab+EFB (60 Ah) L+",
                    Description = "Аккумулятор 6СТ-60 \"E-LAB + EFB\" предназначен для использования в автомобилях с повышенным энергопотреблением или с системой Start-Stop. При разработке этой модели инженеры учли особенности эксплуатации более 200 автомобилей и климатические условия России, страны-производителя. Таким образом, полученный продукт адаптирован к возможным изменениям температур и требованиям производителей автомобилей. Разработка основана на технологии \"Enhanced Flooded Battery\" (EFB), что является ключевой особенностью этого аккумулятора.",
                    Price = 241M,
                    Image = urlHttps + "Images/Catalog/akum3.jpg",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "akkumulyatory")
                },
                new AutoPart
                {
                    Name = "Боковое стекло ВАЗ 2101-2107",
                    Description = "Автостекло боковое ВАЗ 2101-2107, 4500FCLS4FD, 1970-2006, BO2101+TKRVC, ОРИГИНАЛ, БОР.",
                    Price = 12M,
                    Image = urlHttps + "Images/Catalog/bokovoe.jpg",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "styokla")
                },
                new AutoPart
                {
                    Name = "Фильтр топливный ВАЗ 2101, 2108",
                    Description = "Топливный фильтр для автомобилей ВАЗ с карбюраторным двигателем.",
                    Price = 1.2M,
                    Image = urlHttps + "Images/Catalog/filtr-toplivnyj.webp",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "toplivnaya-sistema")
                },
                new AutoPart
                {
                    Name = "Амортизаторы Shtokauto газ -50 мм, задние, ВАЗ 2101-2107",
                    Description = "Комплект задних газомасляных амортизаторов \"Shtokauto\" для автомобилей ВАЗ 2101, 2102, 2103, 2104, 2105, 2106, 2107 устанавливаются под укороченные пружины и имеют более жесткие характеристики, относительно стоковых амортизаторов.",
                    Price = 140M,
                    Image = urlHttps + "Images/Catalog/amort.jpg",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "podveska")
                },
                new AutoPart
                {
                    Name = "Насос топливный, погружной 255 лит. час Walbro GSS342",
                    Description = "Насос топливный погружного типа, производительность 255л/час. Подходит для установки в автомобили ВАЗ и иномарки. Диаметр корпуса 38мм, длина корпуса 76мм, входное сечение 7мм, выходное сечение 6мм. В комплект входит сетчатый фильтр, разъем для подключения, шланг с хомутами, защитный чехол, монтажный уплотнитель.",
                    Price = 140M,
                    Image = urlHttps + "Images/Catalog/nasos-top.jpg",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "toplivnaya-sistema")
                },
                new AutoPart
                {
                    Name = "Подрамник с рычагами – ВАЗ 2108-21099, 2113-2115",
                    Description = "Подрамник для автомобилей ВАЗ 2108, 2109, 21099, 2113, 2114, 2115 на резиновых сайлентблоках. Применение материала СТАЛЬ20 позволило получить высокопрочное изделие сравнительно небольшого веса.",
                    Price = 120M,
                    Image = urlHttps + "Images/Catalog/podramnik.jpg",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "podveska")
                },
                new AutoPart
                {
                    Name = "IFREE Майами (Нео-классик) 5.5J R14 4x98 ET-24 DIA-58.6 ",
                    Description = "Автомобильные диски iFree Майами (Нео-классик) реализованы в элегантном дизайне, являются конструктивно прочными.",
                    Price = 152M,
                    Image = urlHttps + "Images/Catalog/lite.jpg",
                    Category = context.Category.FirstOrDefault(c => c.NormalizedName == "shiny-i-diski")
                },
            };

            context.RemoveAll<AutoPart>();

            await context.AutoPart.AddRangeAsync(autoParts);

            context.SaveChanges();
        }

    }
}

