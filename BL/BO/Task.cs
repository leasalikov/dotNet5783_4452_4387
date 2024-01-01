﻿
namespace BO;
public class Task
{
    public required int ID { get; init; }
    public required string Nickname { get; set; }
    public int? longTime { get; set; }
    public string? Description { get; set; }
    public required DateTime Production { get; set; }
    public required Status TaskStatus { get; set; }
    public List<TaskInList>? TaskInLists { get; set; }
    public required MilestoneIdNickname RelatedMilestone { get; set; }
    public DateTime? EstimatedStartDate { get; set; }
    public DateTime? AcualStartNate { get; set; }
    public DateTime? EstimatedEndDate { get; set; }
    public DateTime? deadline { get; set; }
    public DateTime? AcualEndNate { get; set; }
    public string? Product { get; set; }//ToString
    public string? Remaeks { get; set; }
    public required EngineerLevelEnum Difficulty { get; set; }
    public EngineerInList? EngineerIdName { get; init; }

}