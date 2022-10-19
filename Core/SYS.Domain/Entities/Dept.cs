namespace SYS.Domain.Entities;

public class Dept:BaseEntity
{
    public Decimal Price { get; set; }
    public String Description { get; set; }

  
    public List<Owner> Owners { get; set; }
    
}