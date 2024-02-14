
namespace BlImplementation;
using BlApi;
using BO;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    
/// <summary>
/// The function attempts to add a new Task to the database, throwing a specific exception if the Task already exists
/// </summary>
/// <param name="boTask"></param>
/// <exception cref="BO.BlAlreadyExistsException"></exception>
    public int Create(BO.Task boTask)
    {
        try
        {
            DO.Task doTask = BOToDO(boTask);
            return _dal.Task.Create(doTask);
        }
        catch (BO.BlNullPropertyException ex)
        {
            throw new BO.BlAlreadyExistsException($"Task number {boTask.ID} exists");
        }
        catch (Exception ex)
        {
            throw new BO.BlDataBaceOperationFaild($"DataBace operation faild", ex);
        }
    }
    /// <summary>
    /// The function attempts to Delete a Task to the database, throwing a specific exception if the Task dos't exists
    /// </summary>
    public void Delete(int id)
    {
        try
        {
            if (_dal.Dependence.ReadAll().Any(dependence => dependence!.IDPreviousTask == id))
            {
                throw new BO.BlDependesOnIt("There are tasks that rely on it");
            }
            _dal.Task.Delete(id);
        }
        catch (BO.BlDependesOnIt ex)
        {
            throw new BO.BlDoesNotExistException($"Task number {id} dos't exist");
        }
        catch (Exception ex)
        {
            throw new BO.BlDataBaceOperationFaild($"DataBace operation faild", ex);
        }

    }
    /// <summary>
    /// The function fetches an Task by ID from the database, converting it to a business object, or throws an exception if not found.
    /// </summary>
    public BO.Task? Read(int id)
    {
        try
        {
            DO.Task? myTask = _dal.Task.Read(id);
            return DOToBO(myTask);
        }
        catch
        {
            throw new BO.BlDoesNotExistException($"Task number {id} dos't exist");
        }
    }
    /// <summary>
    /// The function retrieves all Tasks from the database, filtering by level if specified, and returns them as business objects
    /// </summary>
    public IEnumerable<BO.Task> ReadAll(BO.Status status = BO.Status.All)
    {
        if (status == BO.Status.All)
        {
            return _dal.Task.ReadAll()
               .Select(doTask => DOToBO(doTask!));
        }
        return from DO.Task doTask in _dal.Task.ReadAll()
               let boTask = DOToBO(doTask)
               where (BO.Status)boTask.TaskStatus == status
               select boTask;
    }
    /// <summary>
    ///The function modifies an Task in the database based on the provided business object, or throws an exception if the Task doesn't exist
    /// </summary>
    public void Update(BO.Task boTask)
    {
        try
        {
            _dal.Task.Update(BOToDO(boTask));
        }
        catch (BO.BlNullPropertyException ex)
        {
            throw new BO.BlDoesNotExistException($"Task number {boTask.ID} dos't exist");
        }
        catch (Exception ex)
        {
            throw new BO.BlDataBaceOperationFaild($"DataBace operation faild", ex);
        }
    }
    /// <summary>
    /// The DOToBO function maps a data object representing an Task to a corresponding business object, including related engineer information if available
    /// </summary>
    private BO.Task DOToBO(DO.Task doTask)
    {
        return new BO.Task
        {
            ID = doTask.ID!,
            Nickname = doTask.Nickname!,
            Description = doTask.Description,
            Production = doTask.Production,
            TaskStatus = FindStatus(doTask),
            TaskList = FindTaskList(doTask.ID),
            RelatedMilestone = findMilestone(doTask.ID),
            EstimatedStartDate = doTask.EstimatedStartDate,
            AcualStartNate = doTask.AcualStartNate,
            EstimatedEndDate = doTask.EstimatedEndDate,
            deadline = doTask.deadline,
            AcualEndNate = doTask.AcualEndNate,
            Product = doTask.Product,
            Remaeks = doTask.Remaeks,
            Difficulty = (BO.EngineerLevelEnum)doTask.Difficulty,
            EngineerIdName = findEngineer(doTask.IDEngineer)
        };
    }
    /// <summary>
    /// The function converts a business object for an Task to a data object, validating details and throwing an exception for any incorrect information
    /// </summary>
    private DO.Task BOToDO(BO.Task boTask)
    {
        if (string.IsNullOrEmpty(boTask.Nickname))
        {
            throw new BlIncorrectDetails("ID and Nickname must have valid values");
        }
        return new DO.Task
        {
            ID = boTask.ID,
            Description = boTask.Description,
            Nickname = boTask.Nickname,
            Milestone = false,
            Production = boTask.Production,
            EstimatedStartDate = boTask.EstimatedStartDate,
            AcualStartNate = boTask.AcualStartNate,
            EstimatedEndDate = boTask.EstimatedEndDate,
            deadline = boTask.deadline,
            AcualEndNate = boTask.AcualEndNate,
            Product = boTask.Product,
            Remaeks = boTask.Remaeks,
            IDEngineer = boTask.EngineerIdName!.ID,
            Difficulty = (DO.EngineerLevelEnum)boTask.Difficulty,
        };
    }
    /// <summary>
    /// The findEngineer function retrieves an engineer's name from the database by ID or throws a NotImplementedException.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    private TasksEngineer findEngineer(int id)
    {
        try
        {
            return new BO.TasksEngineer { ID = 0, Name = "" };
    }
        catch (Exception ex)
        {
            throw new BO.BlNullPropertyException("",ex);
        }
    }
    /// <summary>
    /// The FindIdList function retrieves a list of IDs corresponding to previous tasks associated with a given TaskId from the database.
    /// </summary>
    /// <param name="TaskId"></param>
    /// <returns></returns>
    private List<int> FindIdList(int TaskId)
    {
        return (from doDependence in _dal.Dependence.ReadAll()
                where TaskId == doDependence.IDTask
                select doDependence.IDPreviousTask)
        .ToList();
    }

    /// <summary>
    /// The FindTaskList function fetches a list of tasks associated with a given TaskId from the database, constructing TaskInList objects with relevant details.
    /// </summary>
    /// <param name="TaskId"></param>
    /// <returns></returns>
    private List<TaskInList> FindTaskList(int TaskId)
    {

        return FindIdList(TaskId)
            .Select(id => _dal.Task.Read(id)!)
            .Select(task => new TaskInList
            {
                ID = task.ID,
                Nickname = task.Nickname!,
                Description = task.Description!,
                Status = FindStatus(task)
            })
            .ToList();
    }
    /// <summary>
    /// The FindStatus function determines the status of a task based on its start and end dates, returning a corresponding BO.Status value.
    /// </summary>
    /// <param name="doTask"></param>
    /// <returns></returns>
    private BO.Status FindStatus(DO.Task doTask)
    {
        return (BO.Status)(doTask.EstimatedStartDate is null ? 0
                            : doTask.AcualStartNate is null ? 1
                            : doTask.AcualEndNate is null ? 2
                            : 3);
    }
    /// <summary>
    /// The findMilestone function retrieves the milestone's ID and nickname for a given TaskId from the database,
    /// encapsulating them in a BO.MilestoneIdNickname object, or returns null if not found.
    /// </summary>
    /// <param name="TaskId"></param>
    /// <returns></returns>
    private BO.MilestoneIdNickname findMilestone(int TaskId)
    {
        BO.MilestoneIdNickname? milestone = (from id in FindIdList(TaskId)
                                             let task = _dal.Task.Read(id)!
                                             where task.Milestone == true
                                             select new BO.MilestoneIdNickname
                                             {
                                                 ID = id!,
                                                 NickName = task.Nickname!
                                             }).FirstOrDefault();
        return milestone;
    }
}