namespace SYS.Application.DTOs.OwnerDtos;

public class OwnerUpdateDto:IDto
{
    public string Name { get; set; }
    public string Tel { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int HomeId { get; set; }
}