namespace DalTest;

using Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;


public static class Initialization
{
    private static ITask? s_dalTask;
    private static IDependence? s_dalDependence;
    private static IEngineer? s_dalEngineer;
    private static readonly Random s_rand = new();

    /// <summary>
    /// The function creates the array of Engineers
    /// </summary>
    private static void createEngineer()
    {

        string[] names = {
        "Alice","Bob","Charlie","David","Emma","Frank","Grace","Hannah","Isaac","Julia","Kevin","Linda","Michael","Nora","Oliver","Penny","Quincy","Rachel","Samuel","Tina","Ulysses", "Victoria","William", "Xander","Yvonne","Zachary","Sophia","Ethan","Ava","Liam", "Mia", "Noah","Olivia","Lucas","Charlotte","Elijah","Amelia","Mason","Harper","shani"
        };
        const int minID = 200000000;
        const int maxID = 400000000;

        foreach (string name in names)
        {
            int id = s_rand.Next(minID, maxID);
            string email = $"{names} + @gmail.com";
            EngineerLevelEnum engineerLevel = (EngineerLevelEnum)s_rand.Next(0, Enum.GetValues(typeof(EngineerLevelEnum)).Length);
            int priceOfHour = 40;
            switch (engineerLevel)
            {
                case EngineerLevelEnum.midLevel:
                    priceOfHour = 60;
                    break;
                case EngineerLevelEnum.highLevel:
                    priceOfHour = 80;
                    break;
            }
            Engineer new_engineer = new Engineer(id, name, email, engineerLevel, priceOfHour);
            s_dalEngineer!.Create(new_engineer);
        }
    }

    /// <summary>
    /// The function randoms a date between the two dates it got
    /// </summary>
    private static DateTime createRandomDate(DateTime startDate, DateTime endDate)
    {
        Random rnd = new Random();
        TimeSpan timeSpan = endDate - startDate;
        TimeSpan newSpan = new TimeSpan(0, rnd.Next(0, (int)timeSpan.TotalMinutes), 0);
        DateTime newDate = startDate + newSpan;
        return newDate;
    }
    /// <summary>
    /// The function creates the array of Tasks
    /// </summary>
    private static void createTasks()
    {
        DateTime startDate = new DateTime(2023, 1, 1);
        DateTime endDate = new DateTime(2023, 11, 30);
        List<Engineer> newEngineers = s_dalEngineer.ReadAll();

        for (int i = 0; i < 100; i++)
        {
            DateTime Production = createRandomDate(startDate, endDate);
            DateTime? Start = createRandomDate(Production, endDate);
            DateTime EstimatedCompletion = Start.Value.AddMonths(2);
            DateTime Final = Production.AddMonths(3);
            int IDEngineer = newEngineers[s_rand.Next(newEngineers.Count)].ID;
            DifficultyEnum Difficulty = (DifficultyEnum)new Random().Next(Enum.GetValues(typeof(DifficultyEnum)).Length);
            DO.Task new_task = new(0, null, null, false, Production, Start, EstimatedCompletion, Final, null, null, null, IDEngineer, Difficulty);
            s_dalTask!.Create(new_task);
        }

    }
    /// <summary>
    /// The function creates the array of Dependence
    /// </summary>
    private static void createDependence()
    {
        int _next_task;
        int _prev_task;
        List<DO.Task> newTasks = s_dalTask.ReadAll();
        foreach (var task in newTasks)
        {
            if (newTasks.FindIndex(_task => _task.ID == task.ID) == newTasks.Count - 4)
                break;
            _prev_task = task.ID;
            for (int i = 1; i < 4;)
            {
                _next_task = newTasks[newTasks.FindIndex(_task => _task.ID == task.ID) + i].ID;
                Dependence new_Dependence = new(0, _next_task, _prev_task);
                s_dalDependence!.Create(new_Dependence);
            }
        }
    }
    public static void Do(ITask? dalTask, IEngineer? dalEngineer, IDependence? dalDependency)
    {
        s_dalTask = dalTask ?? throw new Exception("DAL can't be null!");
        s_dalEngineer = dalEngineer ?? throw new Exception("DAL can't be null!");
        s_dalDependence = dalDependency ?? throw new Exception("DAL can't be null!");
        createEngineer();
        createTasks();
        createDependence();
    }
}
