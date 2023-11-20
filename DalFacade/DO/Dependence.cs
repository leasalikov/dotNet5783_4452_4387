namespace DO;
/// <summary>
/// Describes dependencies between tasks 
/// </summary>
/// <param name="ID">unique ID number</param>
/// <param name="IDPendingTask">unique ID pending task</param>
/// <param name="IDPreviousTask">unique ID previous task</param>
public record Dependence
(
    int ID,
    int IDPendingTask,
    int IDPreviousTask
)
{
    public static object count()
    {
        throw new NotImplementedException();
    }
    public Dependence() : this(0, 0, 0) { }
};
