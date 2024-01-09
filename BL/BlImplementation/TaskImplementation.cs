
namespace BlImplementation;
using BlApi;
using BO;
using DalApi;
using DO;
using System.Collections;
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
        //DO.Task doTask = new DO.Task
        //{
        //    ID = boTask.ID,
        //    Description = boTask.Description,
        //    Nickname = boTask.Nickname,
        //    Milestone = false,
        //    Production = boTask.Production,
        //    Start = ,///////////
        //    AcualStartNate = boTask.AcualStartNate,
        //    longTime = boTask.longTime,
        //    deadline = boTask.deadline,
        //    AcualEndNate = boTask.AcualEndNate,
        //    Product = boTask.Product,
        //    Remaeks = boTask.Remaeks,
        //};
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
            ID = doTask.ID,
            Nickname = doTask.Nickname,
            Description = doTask.Description,
            Production = doTask.Production,
            TaskStatus = (BO.Status)(doTask.EstimatedStartDate is null ? 0
                            : doTask.AcualStartNate is null ? 1
                            : doTask.AcualEndNate is null ? 2
                            : 3),
            TaskInLists = null,
            RelatedMilestone = null,
            EstimatedStartDate = doTask.EstimatedStartDate,
            AcualStartNate = doTask.AcualStartNate,
            EstimatedEndDate = doTask.EstimatedEndDate,
            deadline = doTask.deadline,
            AcualEndNate = doTask.AcualEndNate,
            Product = doTask.Product,
            Remaeks = doTask.Remaeks,
            Difficulty = (BO.EngineerLevelEnum)doTask.Difficulty,
            EngineerIdName = findEngineer(doTask.ID)
        };
    }
    private DO.Task BOToDO(BO.Task boTask)
    {
        if (boTask.ID <= 0 || string.IsNullOrEmpty(boTask.Nickname))
        {
            throw new NotImplementedException();
        }
        return new DO.Task { ID = boTask.ID, Nickname = boTask.Nickname,
            Description = boTask.Description, Production=boTask.Production,
            //TaskStatus= boTask.TaskStatus,
            //TaskInLists,
            //RelatedMilestone,
            EstimatedStartDate = boTask.EstimatedStartDate,
            AcualStartNate = boTask.AcualStartNate,
            EstimatedEndDate = boTask.EstimatedEndDate,
            deadline = boTask.deadline,
            AcualEndNate = boTask.AcualEndNate,
            Product = boTask.Product,
            Remaeks = boTask.Remaeks,
            Difficulty = (DO.EngineerLevelEnum)boTask.Difficulty,
          //  EngineerIdName = findEngineer(boTask.ID)
        };
    }

    private EngineerIdName findEngineer(int id)
    {
        try
        {
            return new BO.EngineerIdName { ID = id, Name = _dal.Engineer.Read(id).FName };
        }
        catch
        {
            throw new NotImplementedException();
        }
    }
}