namespace SYS.Domain.Entities;

public class Dues:BaseEntity
{
    public Decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public List<Owner> Owners { get; set; }
}