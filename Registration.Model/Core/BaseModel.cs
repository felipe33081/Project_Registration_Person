using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Model.Core
{
    public class BaseModel : IModel
    {
        [Key]
        [Column("Código")]
        public virtual int Id { get; set; }
    }
}
