
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
//internal class TaskImplementation : ITask
//{
//    private DalApi.IDal _dal = DalApi.Factory.Get;

//    public void Create(BO.Task boTask)
//    {
//        if (boTask.ID <= 0 || boTask.Nickname == null)
//        {
//            throw new BO.BlNullPropertyException("ID and Nickname must have valid values");
//        }
//        DO.Task doTask = new DO.Task
//        {
//            ID = boTask.ID,
//            Description = boTask.Description,
//            Nickname = boTask.Nickname,
//            Milestone = false,/////////
//            Production = boTask.Production,
//            //Start = ///////////
//            AcualStartNate = boTask.AcualStartNate,
//            // longTime = boTask.longTime,
//            deadline = boTask.deadline,
//            AcualEndNate = boTask.AcualEndNate,
//            Product = boTask.Product,
//            Remaeks = boTask.Remaeks,
//            //IDEngineer = /////////////////////////////////////
//            Difficulty = (DO.EngineerLevelEnum)boTask.Difficulty,






            //TaskStatus = (DO.Status)boTask.TaskStatus,
            //TaskStatus = (BO.status)(thisTask!.scheduleDate is null ? 0
            //  : doTask!.StartDate is null ? 1
            //: doTask.ActualEndDate is null ? 2
            //: 3);
            //TaskInLists = boTask.TaskInLists?.Select(t => new DO.TaskInList { /* שלמות השדות של TaskInList */ }).ToList(),
            //RelatedMilestone = new DO.MilestoneIdNickname { /* שלמות השדות של MilestoneIdNickname */ },
            //EstimatedStartDate = boTask.EstimatedStartDate,

            //EstimatedEndDate = boTask.EstimatedEndDate,

        
    

   // bool Milestone,

   // DateTime? Start,
   //int IDEngineer,
            
   //         try
   //     {
   //         int idTask = _dal.Task.Create(doTask);
   //         //return idTask;
   //     }
   //     catch (DO.DalAlreadyExistsException ex)
   //     {
   //         throw new BO.BlAlreadyExistsException($"Task with Id={boTask.ID} already exists", ex);
   //     }





//    ID = boTask.ID,
//            Nickname = boTask.Nickname,
//            longTime = boTask.longTime,
//            Description = boTask.Description,
//            Production = boTask.Production,
//            //TaskStatus = (DO.Status)boTask.TaskStatus,
//            TaskStatus = (BO.status)(thisTask!.scheduleDate is null ? 0
//                            : doTask!.StartDate is null ? 1
//                            : doTask.ActualEndDate is null ? 2
//                            : 3);
////TaskInLists = boTask.TaskInLists?.Select(t => new DO.TaskInList { /* שלמות השדות של TaskInList */ }).ToList(),
////RelatedMilestone = new DO.MilestoneIdNickname { /* שלמות השדות של MilestoneIdNickname */ },
////EstimatedStartDate = boTask.EstimatedStartDate,
//AcualStartNate = boTask.AcualStartNate,
//            //EstimatedEndDate = boTask.EstimatedEndDate,
//            deadline = boTask.deadline,
//            AcualEndNate = boTask.AcualEndNate,
//            Product = boTask.Product,
//            Remaeks = boTask.Remaeks,
//            Difficulty = (DO.EngineerLevelEnum)boTask.Difficulty,
//            EngineerIdName = boTask.EngineerIdName != null ? new DO.EngineerInList { /* שלמות השדות של EngineerInList */ } : null,








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

    //public void Update(BO.Task task)
    //{
    //    throw new NotImplementedException();
    //}

    //private BO.Task DOToBO(DO.Task doTask)
    //{
    //    int ID,
    //string? Description,
    //string? Nickname,
    //bool Milestone,
    //DateTime? Production,
    //DateTime? Start,
    //DateTime? AcualStartNate,
    //int? longTime,
    //DateTime? deadline,
    //DateTime? AcualEndNate,
    //string? Product,
    //string? Remaeks,
    //int IDEngineer,
    //EngineerLevelEnum Difficulty
    //    return new BO.Task
    //    {
    //        ID = doTask.ID,
    //        Nickname = doTask.Nickname,
    //        Description = doTask.Description,
    //        Production = doTask.Production,
    //        TaskStatus = (BO.Status)(doTask.Start is null ? 0
    //                        : doTask.AcualStartNate is null ? 1
    //                        : doTask.AcualEndNate is null ? 2
    //                        : 3),
    //        TaskInLists = null,
    //        RelatedMilestone = null,
    //        EstimatedStartDate = null,
    //        AcualStartNate = null,
    //        EstimatedEndDate = null,
    //        deadline = doTask.deadline,
    //        AcualEndNate = doTask.AcualEndNate,
    //        Product = doTask.Product,//ToString
    //        Remaeks = doTask.Remaeks,
    //        Difficulty = (BO.EngineerLevel)doTask.Difficulty,
    //        EngineerIdName
    //};
    //}

    //private DO.Task BOToDO(BO.Task boTask)
    //{
    //    if (boTask.ID <= 0 || string.IsNullOrEmpty(boTask.Name) || boTask.PriceOfHour > 0 || string.IsNullOrEmpty(boTask.Email))
    //    {
    //        throw new NotImplementedException();
    //    }
    //    return new DO.Engineer { ID = boTask.ID, FName = boTask.Name, Email = boTask.Email, EngineerLevel = (DO.EngineerLevelEnum)boTask.EngineerLevel, PriceOfHour = boTask.PriceOfHour };
    //}
//}
