namespace SYS.Application.DTOs.DuesDtos;

public class DuesUpdateDto:IDto
{
    public int id { get; set; }
    public Decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}