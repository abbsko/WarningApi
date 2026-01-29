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
            case > 100:
                level += 100;
                details.AppendLine(":skull:");
                break;
            case >= 40:
                level += 3;
                details.AppendLine("Dödlig värme utomhus, undvik");
                break;
            case >= 27:
                level += 2;
                details.AppendLine("Hög värme som kan vara farlig");
                break;
            case <= -40:
                level += 3;
                details.AppendLine("Stanna inne, det är actually Day After Tomorrow vibbar ute");
                break;
            case <= -30:
                level += 2;
                details.AppendLine("Undvik att vara ute, den låga temperaturen kan vara farlig");
                break;
            case <= -20:
                level += 1;
                details.AppendLine("Ta på dig en mössa");
                break;
        }

        switch (info.WindSpeed)
        {
            case > 5:
                level += 1;
                details.AppendLine("");
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
