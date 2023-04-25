using System.Text.Json.Serialization;

namespace Simplicate.NET.Models;

public class TimeTable : Base
{

    [JsonPropertyName("start_date")]
    public string? StartDate { get; set; }

    [JsonPropertyName("end_date")]
    public string? EndDate { get; set; }

    [JsonPropertyName("employee")]
    public NameLookup? Employee { get; set; }

    [JsonPropertyName("odd_week")]
    public TimeTableWeek OddWeek { get; set; }

    [JsonPropertyName("even_week")]
    public TimeTableWeek EvenWeek { get; set; }

    public double AveragePerWeek
    {
        get
        {
            double oddWeekHours = CalculateTotalHours(OddWeek);
            double evenWeekHours = CalculateTotalHours(EvenWeek);

            return (oddWeekHours + evenWeekHours) / 2;
        }
        set
        {

        }
    }

    private double CalculateTotalHours(TimeTableWeek week)
    {
        return week.Day1.Hours + week.Day2.Hours + week.Day3.Hours + week.Day4.Hours +
               week.Day5.Hours + week.Day6.Hours + week.Day7.Hours;
    }

}


public class TimeTableWeek
{
    [JsonPropertyName("day_1")]
    public TimeTableDay Day1 { get; set; } = null!;

    [JsonPropertyName("day_2")]
    public TimeTableDay Day2 { get; set; } = null!;

    [JsonPropertyName("day_3")]
    public TimeTableDay Day3 { get; set; } = null!;

    [JsonPropertyName("day_4")]
    public TimeTableDay Day4 { get; set; } = null!;

    [JsonPropertyName("day_5")]
    public TimeTableDay Day5 { get; set; } = null!;

    [JsonPropertyName("day_6")]
    public TimeTableDay Day6 { get; set; } = null!;

    [JsonPropertyName("day_7")]
    public TimeTableDay Day7 { get; set; } = null!;

}


public class TimeTableDay
{
    [JsonPropertyName("hours")]
    public double Hours { get; set; }


}
