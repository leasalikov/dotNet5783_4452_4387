
namespace BO;

public class Engineer
{
    public required int ID { get; init; }
    public required string Name { get; init; }
    public required string Email { get; init; }
    public EngineerLevelEnum EngineerLevel { get; set; }
    public required float PriceOfHour { get; set; }
    // לבדוק אם קיימת משימה 
    public int? TaskID { get; set; }
    public string? TaskNickname { get; set; }
}
