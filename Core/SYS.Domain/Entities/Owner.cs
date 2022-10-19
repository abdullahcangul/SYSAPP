using SYS.Domain.Enums;

namespace SYS.Domain.Entities;


public class Owner:BaseEntity
{
    public string Name { get; set; }
    public string Tel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public OwnerType OwnerType { get; set; }
    
    public int HomeId { get; set; }
    public Home Home { get; set; }
}