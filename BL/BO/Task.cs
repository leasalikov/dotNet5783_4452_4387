
namespace BO;
public class Task
{
    public int ID { get; init; }
    public string? Nickname { get; set; }
    public string? Description { get; set; }
    public DateTime Production { get; set; }
  //   סטטוס
  //   תלויות (מסוג משימה-ברשימה)
  //   אבן דרך קשורה (מזהה וכינוי)
    public DateTime? EstimatedStartDate { get; set; }
    public DateTime? AcualStartNate { get; set; }
    public DateTime? EstimatedEndDate { get; set; }
    public DateTime? deadline { get; set; }
    public DateTime? AcualEndNate { get; set; }
    public string? Product{ get; set; }//ToString
    public string? Remaeks{ get; set; }
    //אם קיים, מזהה ושם המהנדס שהוקצה למשימה 
    //public EngineerLevelEnum Difficulty?{ get; set; }


   //  bool Milestone,
   // int longTime
}