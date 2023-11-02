﻿namespace DalTest;

using Dal;
using DalApi;
using DO;
using System;
using System.Threading.Tasks;

public static class Initialization
{
    private static IEngineer? s_dalEngineer;
    public static IDependence? s_dalDependece;
    public static ITask? s_dalTask;

    private static readonly Random s_rand = new();

    public static object Dependences { get; private set; }

    /// <summary>
    /// 
    /// </summary>
    public static void createEngineer()
    {
        string[] names = {
        "Alice",
        "Bob",
        "Charlie",
        "David",
        "Emma",
        "Frank",
        "Grace",
        "Hannah",
        "Isaac",
        "Julia",
        "Kevin",
        "Linda",
        "Michael",
        "Nora",
        "Oliver",
        "Penny",
        "Quincy",
        "Rachel",
        "Samuel",
        "Tina",
        "Ulysses",
        "Victoria",
        "William",
        "Xander",
        "Yvonne",
        "Zachary",
        "Sophia",
        "Ethan",
        "Ava",
        "Liam",
        "Mia",
        "Noah",
        "Olivia",
        "Lucas",
        "Charlotte",
        "Elijah",
        "Amelia",
        "Mason",
        "Harper",
        "shani"
        };
        const int minID = 200000000;
        const int maxID = 400000000;
        Random rand = new Random();

        for (int i = 0; i < names.Length; i++)
        {
            int id = rand.Next(minID, maxID);
            string name = names[i];
            string email = names[i] + "@gmail.com";
            EngineerLevelEnum engineerLevel = (EngineerLevelEnum)rand.Next(0, Enum.GetValues(typeof(EngineerLevelEnum)).Length);
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
            Engineer engineer = new Engineer(id, name, email, engineerLevel, priceOfHour);
        }
    }

    public static DateTime createRandomDate(DateTime startDate, DateTime endDate)
    {
        Random rnd = new Random();
        TimeSpan timeSpan = endDate - startDate;
        TimeSpan newSpan = new TimeSpan(0, rnd.Next(0, (int)timeSpan.TotalMinutes), 0);
        DateTime newDate = startDate + newSpan;
        return newDate;
    }

    public static void createTasks()
    {
        DateTime startDate = new DateTime(2023, 1, 1);
        DateTime endDate = new DateTime(2023, 11, 30);

        for (int i = 0; i < 100; i++)
        {
            int id = 0;//?
            string Description =


            bool Milestone = false;
            DateTime Production = createRandomDate(startDate, endDate);
            DateTime? Start = createRandomDate(Production, endDate);
            DateTime EstimatedCompletion = Start.AddMonths(2);
            DateTime Final = Start.AddMonths(3);
            DateTime? AcualEndNate = createRandomDate(Start, Final);

            string Product,
            string Remaeks,
            //int IDEngineer = Engineers[.ID];
            DifficultyEnum Difficulty = (DifficultyEnum)rand.Next(0, Enum.GetValues(typeof(DifficultyEnum)).Length);
        }
    }
    public static void createDependence()
    {
        Random rand = new Random();
        int a = rand.Next(Engineers.Count);
        int idEngineer = Engineers[rand.Next(Engineers.Count)].ID;
        int idTask = Tasks[rand.Next(Tasks.Count())].ID;
    }
}
