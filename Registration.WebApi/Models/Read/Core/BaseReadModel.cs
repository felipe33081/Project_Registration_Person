namespace Registration.WebApi.Models.Read.Core
{
    public class BaseReadModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }
    }
}
