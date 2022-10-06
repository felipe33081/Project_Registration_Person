using Registration.Model;
using Registration.Model.Enumerations;
using Registration.WebApi.Models.Update.Core;
using System.ComponentModel.DataAnnotations;

namespace Registration.WebApi.Models.Update.Account
{
    public class ProductUpdateModel : BaseUpdateModel
    {
        public string? Description { get; set; }

        public string? Price { get; set; }

        [EnumDataType(typeof(Category))]
        public Category? Category { get; set; }
    }
}
