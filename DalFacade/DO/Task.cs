

namespace DO;

/// <summary>
/// describes the tasks of the enigneersin the company
/// </summary>
/// <param name="Description">describes the task</param>
/// <param name="Nickname">the name that calls the task</param>
/// <param name="Milestone">?????????????????</param>
/// <param name="Production">task creation date</param>
/// <param name="Start">task start date</param>
/// <param name="EstimatedCompletion">estimated date for completion of the task</param>
/// <param name="Final">last date for completing the task</param>
/// <param name="AcualEndNate">actual assignment completion date</param>
/// <param name="Product">what should come out at the end of the mission</param>
/// <param name="Remaeks">notes to the engineer</param>
/// <param name="">identify the engineer assigned to the task</param>
public record Task
(
    //מספר מזהה רץ
    string Description,
    string Nickname,
    bool Milestone,
    DateTime Production,
    DateTime? Start,
    DateTime EstimatedCompletion,
    DateTime Final,
    DateTime? AcualEndNate,
    string Product,
    string Remaeks,
    //Engineer
    //Difficulty
);
    

