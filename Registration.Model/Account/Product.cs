using Registration.Model.Core;
using Registration.Model.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Model.Account
{
    public class Product : BaseModel
    {
        [Required]
        [Column("Descrição")]
        public string? Description { get; set; }

        [Required]
        [Column("Preço")]
        public string? Price { get; set; }

        [Column("Categoria")]
        [EnumDataType(typeof(Category))]
        public Category? Category { get; set; }
    }
}
