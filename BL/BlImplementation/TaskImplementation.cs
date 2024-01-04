
namespace BlImplementation;
using BlApi;
using BO;
using System.Collections.Generic;

/////
////////
//ציפי המדהימה!!! לא עשיתי הרבה דברים עדיין בפנקיות שלי.... אני היום לא נירלי הולכת לעבוד על זה יותר, בע"ה המשך יבוא....
/// <summary>
/// 
/// </summary>
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
           // (from DO.Task doTask in _dal.Task.ReadAll() where doTask.IDEngineer == doEngineer.ID select new BO.TaskIdNickname() { ID = doTask.ID, Nickname = doTask.Nickname }).First()
            //Engineer = (from DO.Engineer doEngineer in _dal.Engineer.)
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

    public IEnumerable<Task> ReadAll()
    {
        throw new NotImplementedException();
    }

    //public IEnumerable<BO.Task> ReadAll()
    //{
    //    _dal.Engineer.ReadAll();
    //    //return (IEnumerable<BO.Task>)from DO.Task doTask in _dal.Task.ReadAll()
    //    //                             select new BO.Task
    //    //                             {
    //    //                                 ID = doTask.ID,
    //    //                                 Nickname = doTask.Nickname,
    //    //                                 longTime = doTask.longTime,
    //    //                                 Description = doTask.Description,
    //    //                                 Production = doTask.Production,
    //    //                                 //TaskStatus = (DO.Status)doTask.TaskStatus,
    //    //                                 //TaskInLists = doTask.TaskInLists?.Select(t => new DO.TaskInList { /* שלמות השדות של TaskInList */ }).ToList(),
    //    //                                 //RelatedMilestone = new DO.MilestoneIdNickname { /* שלמות השדות של MilestoneIdNickname */ },
    //    //                                 //EstimatedStartDate = doTask.EstimatedStartDate,
    //    //                                 AcualStartNate = doTask.AcualStartNate,
    //    //                                 //EstimatedEndDate = doTask.EstimatedEndDate,
    //    //                                 deadline = doTask.deadline,
    //    //                                 AcualEndNate = doTask.AcualEndNate,
    //    //                                 Product = doTask.Product,
    //    //                                 Remaeks = doTask.Remaeks,
    //    //                                 //Difficulty = (DO.EngineerLevelEnum)doTask.Difficulty,
    //    //                                 EngineerIdName = (from DO.Engineer doEngineer in _dal.Engineer.ReadAll() where doTask.IDEngineer == doEngineer.ID select new BO.() { ID = doTask.ID, Nickname = doTask.Nickname }).First()
    //    //                                 //EngineerIdName = doTask.EngineerIdName != null ? new DO.EngineerInList { /* שלמות השדות של EngineerInList */ } : null,

    //    //                             };
    //}

    public void Update(BO.Task task)
    {
        throw new NotImplementedException();
    }
}
