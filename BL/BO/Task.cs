
namespace BO;
public class Task
{
    public int ID { get; init; }
    public string? Nickname { get; set; }
    public string? Description { get; set; }
    public DateTime Production { get; set; }
    public Status? TaskStatus { get; set; }

    //   תלויות (מסוג משימה-ברשימה)
    public List<TaskInList>? taskInLists { get; set; }//?
    //   אבן דרך קשורה (מזהה וכינוי)
    public bool Milestone { get; set; }//??

    public DateTime? EstimatedStartDate { get; set; }
    public DateTime? AcualStartNate { get; set; }
    public DateTime? EstimatedEndDate { get; set; }
    public DateTime? deadline { get; set; }
    public DateTime? AcualEndNate { get; set; }
    public string? Product { get; set; }//ToString
    public string? Remaeks { get; set; }
    public EngineerLevelEnum? Difficulty { get; set; }

    //אם קיים מהנדס
    public int EngineerID { get; init; }
    public string? EngineerName { get; set; }
}