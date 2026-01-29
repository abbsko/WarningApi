namespace WarningApi.Business;

public class Warning
{
    public required int Level { get; set; }
    public required string Details { get; set; } = string.Empty;
}
