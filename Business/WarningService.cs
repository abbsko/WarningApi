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

        return new Warning()
        {
            Level = level,
            Details = details.ToString()
        };
    }
}
