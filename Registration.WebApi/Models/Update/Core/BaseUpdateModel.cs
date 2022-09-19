namespace Registration.WebApi.Models.Update.Core
{
    public class BaseUpdateModel
    {
        public Guid Id { get; set; }

        public DateTimeOffset? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public bool? IsDeleted { get; set; }
    }
}
