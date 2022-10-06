namespace Registration.WebApi.Models.Update.Core
{
    public class BaseUpdateModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public string? UpdatedBy { get; set; } = "System";

        public bool? IsDeleted { get; set; }
    }
}
