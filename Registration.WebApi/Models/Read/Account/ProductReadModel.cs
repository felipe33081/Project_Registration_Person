using Registration.Model.Enumerations;
using Registration.Model;
using Registration.WebApi.Models.Read.Core;
using System.ComponentModel.DataAnnotations;
using Registration.WebApi.Models.Create;

namespace Registration.WebApi.Models.Read.Account
{
    public class ProductReadModel : BaseReadModel
    {
        public string? Description { get; set; }

        public string? Price { get; set; }

        [EnumDataType(typeof(Category))]
        public Category? Category { get; set; }
    }
}
