using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEB_153504_Gaikevich.Domain.Entities
{
	public class Category
	{
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public required string NormalizedName { get; set; }
        //[InverseProperty("Category")]
        //public ICollection<AutoPart>? AutoParts { get; set; }
    }
}
