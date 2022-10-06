using Registration.Model;
using Registration.Model.Enumerations;
using Registration.WebApi.Models.Create.Core;
using System.ComponentModel.DataAnnotations;

namespace Registration.WebApi.Models.Create.Account
{
    public class ProductCreateModel : BaseCreateModel
    {
        [Required]
        public string? Description { get; set; }

        [Required]
        public string? Price { get; set; }

        [EnumDataType(typeof(Category))]
        public Category? Category { get; set; }
    }
}
