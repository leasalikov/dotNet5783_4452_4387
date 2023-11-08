

namespace DO;

/// <summary>
/// describes the tasks of the enigneersin the company
/// </summary>
/// <param name="ID">unique ID number</param>
/// <param name="Description">Describes the task</param>
/// <param name="Nickname">The name that calls the task</param>
/// <param name="Milestone">כינוי המשימה</param>
/// <param name="Production">Task creation date</param>
/// <param name="Start">Task start date</param>
/// <param name="AcualStartNate">Actual start date</param>
/// <param name="longTime">long time that take to do the task</param>
/// <param name="deadline">Last date for completing the task</param>
/// <param name="AcualEndNate">Actual assignment completion date</param>
/// <param name="Product">What should come out at the end of the mission</param>
/// <param name="Remaeks">Notes to the engineer</param>
/// <param name="IDEngineer">engineers ID</param>
/// <param name="Difficulty">Difficulty level of the task</param>
public record Task
(
    int ID,
    string? Description,
    string? Nickname,
    bool Milestone,
    DateTime Production,
    DateTime? Start,
    DateTime? AcualStartNate,
    int longTime,
    DateTime? deadline,
    DateTime? AcualEndNate,
    string? Product,
    string? Remaeks,
    int IDEngineer,
    EngineerLevelEnum Difficulty
);


