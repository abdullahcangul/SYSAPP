namespace SYS.Domain.Entities;

public class Home:BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }

    public List<Dues> Dueses { get; set; }
}