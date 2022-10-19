namespace SYS.Application.DTOs.DeptDtos;

public class DeptUpdateDto:IDto
{
    public int id { get; set; }
    public Decimal Price { get; set; }
    public String Description { get; set; }
}