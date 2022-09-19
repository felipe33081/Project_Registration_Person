namespace Registration.WebApi.Models.Create.Core
{
    public class BaseCreateModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }
        
        public bool? IsDeleted { get; set; }
    }
}
