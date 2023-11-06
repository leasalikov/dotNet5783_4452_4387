using Dal;
using DalApi;
using System.Runtime.CompilerServices;

namespace DalTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            private static IEngineer? s_dalTask = new EngineerImplementation();
            private static IDependence? s_dalDependence = new DependenceImplementation();
            private static ITask? s_dalEngineer = new TaskImplementation();
            Initialization.Do(s_dalTask, s_dalDependence, s_dalEngineer);
        }
    }
}
