namespace SYS.Application.DTOs.DuesDtos;

public class DuesAddDto:IDto
{
    public Decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}