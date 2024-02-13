
namespace BO;

public class TaskInList
{
    public required int ID {  get; init; }
    public required string Nickname { get; init; }
    public required string Description { get; init; }
    public Status? Status { get; init; }
}