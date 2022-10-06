using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Registration.Model.Core
{
    public class BaseModel : IModel
    {
        [Key]
        [Column("Código")]
        public virtual int Id { get; set; }

        [Required]
        [Column("Criado_Em")]
        public virtual DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
        
        [Column("Atualizado_Em")]
        public virtual DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("Criado_Por")]
        public virtual string? CreatedBy { get; set; } = "System";

        [Column("Atualizado_Por")]
        public virtual string? UpdatedBy { get; set; } = "System";


        public virtual bool IsDeleted { get; set; } = false;
    }
}
