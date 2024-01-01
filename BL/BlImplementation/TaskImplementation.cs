
namespace BlImplementation;
using BlApi;

internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public void Create(BO.Task boTask)
    {
        if (boTask.ID <= 0 || boTask.Nickname == null)
        {
            throw new BO.BlNullPropertyException("ID and Nickname must have valid values");
        }
        DO.Task doTask = new DO.Task
        {
            ID = boTask.ID,
            Nickname = boTask.Nickname,
            longTime = boTask.longTime,
            Description = boTask.Description,
            Production = boTask.Production,
            //TaskStatus = (DO.Status)boTask.TaskStatus,
            //TaskInLists = boTask.TaskInLists?.Select(t => new DO.TaskInList { /* שלמות השדות של TaskInList */ }).ToList(),
            //RelatedMilestone = new DO.MilestoneIdNickname { /* שלמות השדות של MilestoneIdNickname */ },
            //EstimatedStartDate = boTask.EstimatedStartDate,
            AcualStartNate = boTask.AcualStartNate,
            //EstimatedEndDate = boTask.EstimatedEndDate,
            deadline = boTask.deadline,
            AcualEndNate = boTask.AcualEndNate,
            Product = boTask.Product,
            Remaeks = boTask.Remaeks,
            Difficulty = (DO.EngineerLevelEnum)boTask.Difficulty,
            //EngineerIdName = boTask.EngineerIdName != null ? new DO.EngineerInList { /* שלמות השדות של EngineerInList */ } : null,

        };
        try
        {
            int idTask = _dal.Task.Create(doTask);
            //return idTask;
        }
        catch (DO.DalAlreadyExistsException ex)
        {
            throw new BO.BlAlreadyExistsException($"Task with Id={boTask.ID} already exists", ex);
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Task? Read(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BO.Task> ReadAll()
    {
        throw new NotImplementedException();
    }

    public void Update(BO.Task task)
    {
        throw new NotImplementedException();
    }
}
