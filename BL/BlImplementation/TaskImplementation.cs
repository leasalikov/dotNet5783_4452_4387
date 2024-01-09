
namespace BlImplementation;
using BlApi;
using BO;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Threading.Tasks;

internal class TaskImplementation : ITask
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public int Create(BO.Task boTask)
    {
        if (boTask.ID <= 0 || boTask.Nickname == null)
        {
            throw new BO.BlNullPropertyException("ID and Nickname must have valid values");
        }
        try
        {
            DO.Task doTask = BOToDO(boTask);
            _dal.Task.Create(doTask);
            return doTask.ID;
        }
        catch
        {
            return 0;
        }
    }
    public void Delete(int id)
    {
        DO.Task? doTask = _dal.Task.Read(id);
        // if ((from DO.Task doTask in _dal.Task.ReadAll() select doTask.IDEngineer == id) == null)
        if ((from DO.Engineer doEngineer in _dal.Engineer.ReadAll() select doEngineer.ID == id) == null)//?????????????????????????
        {
            _dal.Task.Delete(id);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    public BO.Task? Read(int id)
    {
        try
        {
            DO.Task? myTask = _dal.Task.Read(id);
            if (myTask == null)
            {
                throw new InvalidOperationException();//חריגה שאין מתכנת עם הID שהתקבל
            }
            return DOToBO(myTask);
        }
        catch
        {
            /////////////////////??????????????????????????
            return null;
        }
    }

    public IEnumerable<BO.Task> ReadAll()
    {
        return from DO.Task doTask in _dal.Task.ReadAll()
               select DOToBO(doTask);
    }

    public void Update(BO.Task boTask)
    {
        try
        {
            _dal.Task.Update(BOToDO(boTask));
        }
        catch
        {
        }
    }

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
            RelatedMilestone = findMilestone(TaskList),
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

    private DO.Task BOToDO(BO.Task boTask)
    {
        if (boTask.ID <= 0 || string.IsNullOrEmpty(boTask.Nickname))
        {
            throw new NotImplementedException();
        }
        return new DO.Task { 
            ID = boTask.ID, 
            Description = boTask.Description,
            Nickname = boTask.Nickname,
            Milestone = false,//??
            Production =boTask.Production,
            EstimatedStartDate = boTask.EstimatedStartDate,
            AcualStartNate = boTask.AcualStartNate,
            EstimatedEndDate = boTask.EstimatedEndDate,
            deadline = boTask.deadline,
            AcualEndNate = boTask.AcualEndNate,
            Product = boTask.Product,
            Remaeks = boTask.Remaeks,
            IDEngineer = boTask.EngineerIdName.ID,
            Difficulty = (DO.EngineerLevelEnum)boTask.Difficulty,
        };
    }

    private TasksEngineer findEngineer(int id)
    {
        try
        {
            return new BO.TasksEngineer { ID = id, Name = _dal.Engineer.Read(id)!.Name };
        }
        catch
        {
            throw new NotImplementedException();
        }
    }
    private List<TaskInList> FindTaskList(int TaskId)
    {
        var idList = (from doDependence in _dal.Dependence.ReadAll()
                      where TaskId == doDependence.IDTask
                      select doDependence.IDPreviousTask)
                .ToList();

        List<TaskInList> taskList = idList
            .Select(id => _dal.Task.Read(id)!)
            .Select(task => new TaskInList
            {
                ID = task.ID,
                Nickname = task.Nickname!,
                Description = task.Description!,
                Status = FindStatus(task)
            })
            .ToList();

        return taskList;
    }

    private BO.Status FindStatus(DO.Task doTask)
    {
        return (BO.Status)(doTask.EstimatedStartDate is null ? 0
                            : doTask.AcualStartNate is null ? 1
                            : doTask.AcualEndNate is null ? 2
                            : 3);
    }
    
    private BO.MilestoneIdNickname findMilestone(List<TaskInList> tasks)
    {
        from task in tasks
        where _dal.Task.Read(task.ID).Milestone == true
        select new BO.MilestoneIdNickname
        {
            ID = task.ID,
            NickName = task.Nickname!

        }


    }
}