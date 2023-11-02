namespace DalTest;

using Dal;
using DalApi;
using DO;
using System;

public static class Initialization
{
    private static IEngineer? s_dalEngineer;
    public static IDependence? s_dalDependece;
    public static ITask? s_dalTask;
    
    private static readonly Random s_rand = new();

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

        for (int i=0; i<names.Length; i++)
        {
            int id = rand.Next(minID, maxID);
            string name = names[i];
            string email = names[i]+"@gmail.com";
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
            Engineer engineer =new Engineer(id,name,email,engineerLevel,priceOfHour);
        }
    }
}
