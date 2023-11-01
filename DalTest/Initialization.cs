namespace DalTest;

using Dal;
using DalApi;
using DO;

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
    "Harper"
        };
        const int minID = 200000000;
        const int maxID = 400000000;
        Random rand = new();

        for (int i=0; i<names.Length; i++)
        {
            int id = rand.Next(minID, maxID);
            string FName = names[i];
            string Email = names[i]+"@gmail.com";
            int EngineerLevel = rand.Next(1,3);

            Engineer engineer =new Engineer();

        }
        foreach (Engineer engineer in names)
        {

        }
        foreach (Engineer engineer in names) ;
    }
}
