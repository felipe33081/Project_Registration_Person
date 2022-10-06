namespace Registration.WebApi.Models.Create.Core
{
    public class BaseCreateModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        public string? CreatedBy { get; set; } = "System";

        public DateTimeOffset? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }
        
        public bool? IsDeleted { get; set; }
    }
}
