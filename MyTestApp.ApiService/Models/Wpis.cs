namespace MyTestApp.ApiService.Models;

public class Wpis
{
    public int Id { get; set; }
    public string Tresc { get; set; } = "";
    public DateTime DataDodania { get; set; } = DateTime.UtcNow;
}
