using System.Text;

namespace WarningApi.Business;

public class WarningService
{
    public Warning GetWarning(WeatherInfo info)
    {
        var level = 0;
        var details = new StringBuilder();

        if (info.Temperature <= -4)
        {
            level += 1;
            details.AppendLine("Risk för halka");
        }

        switch (info.Temperature)
        {
            case < -40:
                level += 3;
                details.AppendLine("Stanna inne, det är actually Day After Tomorrow vibbar ute");
                break;
            case < -30:
                level += 2;
                details.AppendLine("Undvik att vara ute, den låga temperaturen kan vara farlig");
                break;
            case < -20:
                level += 1;
                details.AppendLine("Ta på dig en mössa");
                break;
        }
        
        switch (info.WindSpeed)
        {
            case < 15: 
                level += 1;
                details.AppendLine("Hög vindhastighet");
                break;
            case < 20: 
                level += 1;
                details.AppendLine("Väldigt hög vindhastighet");
                break;
            case < 25: 
                level += 2;
                details.AppendLine("Storm");
                break;
            case < 30: 
                level += 2;
                details.AppendLine("Våldsam storm");
                break;
            case < 35:
                level += 3;
                details.AppendLine("Hurrikan");
                break;
            case < 45:
                level += 3;
                details.AppendLine("Våldsam hurrikan");
                break;
            default: 
                level += 4;
                details.AppendLine("Tornad");
                break;
        }

        if (level > 0)
        {
            details.Insert(0, "!!VARNING!!\n");
        }

        return new Warning()
        {
            Level = level,
            Details = details.ToString()
        };
    }
}
