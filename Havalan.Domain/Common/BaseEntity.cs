namespace Havalan.Domain.Base;
public class BaseEntity
{
    public long Id { get; set; }
    public DateTime CreationDate { get; set; } = DateTime.Now;
}