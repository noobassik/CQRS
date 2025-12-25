namespace CQRS.Domain.Abstractions
{
    public abstract class Entity<T> : IEntity<T>
    {
        public required T Id { get; set; }

        public bool IsDeleted { get; set; } = default;
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
