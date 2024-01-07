
namespace BlImplementation;
using BlApi;
using BO;
using DalApi;
using System.Collections;
using System.Collections.Generic;

/////
////////
//ציפי המדהימה!!! לא עשיתי הרבה דברים עדיין בפנקיות שלי.... אני היום לא נירלי הולכת לעבוד על זה יותר, בע"ה המשך יבוא....
/// <summary>
/// 
/// </summary>
//internal class TaskImplementation : ITask
//{
//    private DalApi.IDal _dal = DalApi.Factory.Get;

    public void Create(BO.Task boTask)
    {
        if (boTask.ID <= 0 || boTask.Nickname == null)
        {
            throw new BO.BlNullPropertyException("ID and Nickname must have valid values");
        }
        DO.Task doTask = new DO.Task
        {
            ID = boTask.ID,
            Description = boTask.Description,
            Nickname = boTask.Nickname,
            Milestone = false,
            Production = boTask.Production,
            Start = ,///////////
            AcualStartNate = boTask.AcualStartNate,
            longTime = boTask.longTime,
            deadline = boTask.deadline,
            AcualEndNate = boTask.AcualEndNate,
            Product = boTask.Product,
            Remaeks = boTask.Remaeks,
        };
    }







    //public void Delete(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public BO.Task? Read(int id)
    //{
    //    throw new NotImplementedException();
    //}

    //public IEnumerable<Task> ReadAll()
    //{
    //    throw new NotImplementedException();
    //}

    public void Update(BO.Task task)
    {
        throw new NotImplementedException();
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
            Difficulty = (BO.EngineerLevel)doTask.Difficulty,
            EngineerIdName = findEngineer(doTask.ID)
        };
    }
    private DO.Task BOToDO(BO.Task boTask)
    {
        if (boTask.ID <= 0 || string.IsNullOrEmpty(boTask.Name) || boTask.PriceOfHour > 0 || string.IsNullOrEmpty(boTask.Email))
        {
            throw new NotImplementedException();
        }
        return new DO.Engineer { ID = boTask.ID, FName = boTask.Name, Email = boTask.- Email, EngineerLevel = (DO.EngineerLevelEnum)boTask.EngineerLevel, PriceOfHour = boTask.PriceOfHour };
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
