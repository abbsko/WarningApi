namespace WarningApi.Business;

public class WeatherInfo
{
    public required DateOnly Date { get; set; }
    public required int Temperature { get; set; }
    public required string Description { get; set; }
    public required int WindSpeed { get; set; }
    public required string City { get; set; }
}