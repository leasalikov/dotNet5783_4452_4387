//namespace BlImplementation;
//using BlApi;
//using BO;
//using DalApi;
//using DO;
//using System.Collections;
//using System.Collections.Generic;

//internal class TaskImplementation : ITask
//{
//    private DalApi.IDal _dal = DalApi.Factory.Get;

//    public int Create(BO.Task boTask)
//    {
//        if (boTask.ID <= 0 || string.IsNullOrEmpty(boTask.Nickname))
//        {
//            throw new BO.BlNullPropertyException("ID and Nickname must have valid values");
//        }
//        try
//        {
//            DO.Task doTask = BOToDO(boTask);
//            _dal.Task.Create(doTask);
//            return doTask.ID;
//        }
//        catch (Exception ex)
//        {
//            // Log or handle the exception appropriately
//            return 0;
//        }
//    }

//    public void Delete(int id)
//    {
//        try
//        {
//            DO.Task? doTask = _dal.Task.Read(id);
//            if (doTask != null)
//            {
//                // Check if the task is associated with any engineer
//                if (!_dal.Engineer.ReadAll().Any(e => e.ID == id))
//                {
//                    _dal.Task.Delete(id);
//                }
//                else
//                {
//                    throw new InvalidOperationException("Task is associated with an engineer and cannot be deleted.");
//                }
//            }
//        }
//        catch (Exception ex)
//        {
//            // Log or handle the exception appropriately
//            throw;
//        }
//    }

//    public BO.Task? Read(int id)
//    {
//        try
//        {
//            DO.Task? myTask = _dal.Task.Read(id);
//            if (myTask == null)
//            {
//                throw new InvalidOperationException($"No task found with ID {id}");
//            }
//            return DOToBO(myTask);
//        }
//        catch (Exception ex)
//        {
//            // Log or handle the exception appropriately
//            return null;
//        }
//    }

//    public IEnumerable<BO.Task> ReadAll()
//    {
//        return _dal.Task.ReadAll().Select(DOToBO);
//    }

//    public void Update(BO.Task boTask)
//    {
//        try
//        {
//            _dal.Task.Update(BOToDO(boTask));
//        }
//        catch (Exception ex)
//        {
//            // Log or handle the exception appropriately
//        }
//    }

//    private BO.Task DOToBO(DO.Task doTask)
//    {
//        return new BO.Task
//        {
//            ID = doTask.ID,
//            Nickname = doTask.Nickname,
//            Description = doTask.Description,
//            Production = doTask.Production,
//            TaskStatus = (BO.Status)(doTask.EstimatedStartDate == null ? 0
//                            : doTask.AcualStartNate == null ? 1
//                            : doTask.AcualEndNate == null ? 2
//                            : 3),
//            TaskInLists = null,
//            RelatedMilestone = null,
//            EstimatedStartDate = doTask.EstimatedStartDate,
//            AcualStartNate = doTask.AcualStartNate,
//            EstimatedEndDate = doTask.EstimatedEndDate,
//            Deadline = doTask.Deadline,
//            AcualEndNate = doTask.AcualEndNate,
//            Product = doTask.Product,
//            Remaeks = doTask.Remarks,
//            Difficulty = (BO.EngineerLevel)doTask.Difficulty,
//            EngineerIdName = findEngineer(doTask.ID)
//        };
//    }

//    private DO.Task BOToDO(BO.Task boTask)
//    {
//        if (boTask.ID <= 0 || string.IsNullOrEmpty(boTask.Nickname))
//        {
//            throw new ArgumentException("ID and Nickname must have valid values");
//        }

//        return new DO.Task
//        {
//            ID = boTask.ID,
//            Description = boTask.Description,
//            Nickname = boTask.Nickname,
//            Milestone = false,
//            Production = boTask.Production,
//            EstimatedStartDate = boTask.EstimatedStartDate,
//            AcualStartNate = boTask.AcualStartNate,
//            EstimatedEndDate = boTask.EstimatedEndDate,
//            //Deadline = boTask.Deadline,
//            AcualEndNate = boTask.AcualEndNate,
//            Product = boTask.Product,
//           // Remarks = boTask.Remarks,
//            Difficulty = (DO.EngineerLevelEnum)boTask.Difficulty
//        };
//    }

//    private EngineerIdName findEngineer(int id)
//    {
//        try
//        {
//            return new BO.EngineerIdName { ID = id, Name = _dal.Engineer.Read(id).FName };
//        }
//        catch (Exception ex)
//        {
//            // Log or handle the exception appropriately
//            throw;
//        }
//    }
//}
namespace BlImplementation;
using BlApi;
using BO;
using DalApi;
using DO;
using System.Collections;
using System.Collections.Generic;



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