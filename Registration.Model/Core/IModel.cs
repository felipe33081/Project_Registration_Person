namespace Registration.Model.Core
{
    public interface IModel
    {
        Guid Id { get; set; }

        DateTimeOffset CreatedAt { get; set; }

        DateTimeOffset? UpdatedAt { get; set; }

        string CreatedBy { get; set; }

        string UpdatedBy { get; set; }

        bool IsDeleted { get; set; }
    }
}
