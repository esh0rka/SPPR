using System;
using System.ComponentModel.DataAnnotations;

namespace WEB_153504_Gaikevich.Domain.Entities
{
	public class AutoPart
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = "";
        public Category? Category { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public string? mimeType { get; set; }
    }
}

