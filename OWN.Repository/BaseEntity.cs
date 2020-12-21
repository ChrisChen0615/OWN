namespace OWN.Repository
{
    public abstract class BaseEntity<TPrimaryKey> : IBaseEntity<TPrimaryKey>
    {
        public virtual TPrimaryKey Id { get; set; }
    }
}
