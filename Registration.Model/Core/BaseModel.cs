using System.ComponentModel.DataAnnotations;

namespace Registration.Model.Core
{
    public class BaseModel : IModel
    {
        [Key]
        public virtual Guid Id { get; set; }

        [Required]
        public virtual DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public virtual DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public virtual string? CreatedBy { get; set; }

        public virtual string? UpdatedBy { get; set; }

        public virtual bool IsDeleted { get; set; } = false;
    }
}
