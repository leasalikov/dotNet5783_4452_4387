

namespace DO;

/// <summary>
/// describes the tasks of the enigneersin the company
/// </summary>
/// <param name="Description">Describes the task</param>
/// <param name="Nickname">The name that calls the task</param>
/// <param name="Milestone">?????????????????</param>
/// <param name="Production">Task creation date</param>
/// <param name="Start">Task start date</param>
/// <param name="EstimatedCompletion">Estimated date for completion of the task</param>
/// <param name="Final">Last date for completing the task</param>
/// <param name="AcualEndNate">Actual assignment completion date</param>
/// <param name="Product">What should come out at the end of the mission</param>
/// <param name="Remaeks">Notes to the engineer</param>
/// <param name="Difficulty">Difficulty level of the task</param>
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
    //IDEngineer
    DifficultyEnum Difficulty
);
    

