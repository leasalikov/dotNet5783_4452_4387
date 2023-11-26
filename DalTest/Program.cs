using DalApi;
using DO;
using Dal;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data.SqlTypes;

namespace DalTest
{
    internal class Program
    {
        //private static IDal? s_dal = new DalList();
        static readonly IDal? s_dal = new DalXml();
        static void Main(string[] args)
        {
            try
            {
                generalMenue();
                Initialization.Do(s_dal);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }

        /// <summary>
        /// create new task entity recording to the input data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DO.Task createTask(int id = 0000)
        {
            Console.WriteLine("enter description");
            string Description = Console.ReadLine()!;
            Console.WriteLine("enter product");
            string Nickname = Console.ReadLine()!;
            Console.WriteLine("enter engineer id");
            int IDEngineer = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("enter a nickname");
            string Product = Console.ReadLine()!;
            Console.WriteLine("enter a comment");
            string Remaeks = Console.ReadLine()!;
            Console.WriteLine("enter engineer level");
            int Elevel = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter date created");
            DateTime Production;
            DateTime.TryParse(Console.ReadLine(), out Production);
            Console.WriteLine("Enter date started");
            DateTime Start;
            DateTime.TryParse(Console.ReadLine(), out Start);
            Console.WriteLine("enter a long time that take for the task");
            int longTime = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter date acual start");
            DateTime AcualStartNate;
            DateTime.TryParse(Console.ReadLine(), out AcualStartNate);
            Console.WriteLine("Enter date of deadline");
            DateTime deadline;
            DateTime.TryParse(Console.ReadLine(), out deadline);
            Console.WriteLine("Enter date of complete");
            DateTime AcualEndNate;
            DateTime.TryParse(Console.ReadLine(), out AcualEndNate);
            return (new DO.Task(0, Description, Nickname, false, Production, Start, AcualStartNate, longTime, deadline, AcualEndNate, Product, Remaeks, IDEngineer, (EngineerLevelEnum)Elevel));
        }
        /// <summary>
        /// managing the task's entity menu.
        /// </summary>
        public static void taskMenu()
        {
            string? choose = null;
            do
            {
                Console.WriteLine("Enter method choice: (Exit, Create, Read, ReadAll, Update, Delete)");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "Exit":
                        break;
                    case "Create":
                        s_dal.Task!.Create(createTask());
                        break;
                    case "Read":
                        Console.WriteLine("enter task's id");
                        Console.WriteLine(s_dal!.Task.Read(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "ReadAll":
                        foreach (var item in s_dal.Task.ReadAll())
                            Console.WriteLine(item);
                        break;
                    case "Update":
                        Console.WriteLine("Enter task's id");
                        s_dal!.Task.Update(createTask(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "Delete":
                        Console.WriteLine("enter task's id");
                        s_dal!.Task.Delete(Convert.ToInt32(Console.ReadLine()));
                        break;
                    default:
                        Console.WriteLine("you entered worng choose");
                        break;
                }
            } while (choose != "Exit");
            return;
        }

        /// <summary>
        /// create new engineer entity recording to the input data.
        /// </summary>
        /// <returns></returns>

        private static Engineer createEngineer()
        {
            int id;
            string name;
            string email;
            int level;
            int cost_per_houer;
            Console.WriteLine("Enter id:");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name:");
            name = Console.ReadLine()!;
            Console.WriteLine("Enter email:");
            email = Console.ReadLine()!;
            Console.WriteLine("Enter level (Novice = 0, AdvancedBeginner = 1, Competent = 2, Proficient = 3, Expert = 4):");
            level = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cost per hour:");
            cost_per_houer = Convert.ToInt32(Console.ReadLine());
            return new Engineer(id, name!, email!, (EngineerLevelEnum)level, cost_per_houer);
        }

        /// <summary>
        /// managing the engineer's entity menu.
        /// </summary>
        public static void engineerMenu()
        {
            string? choose;
            do
            {
                Console.WriteLine("Enter method choice: (Exit, Create, Read, ReadAll, Update, Delete)");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "Exit":
                        break;
                    case "Create":
                        s_dal!.Engineer.Create(createEngineer());
                        break;
                    case "Read":
                        Console.WriteLine("enter engineer's id");
                        Console.WriteLine(s_dal!.Engineer.Read(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "ReadAll":
                        foreach (var item in s_dal!.Engineer.ReadAll())
                        {
                            Console.WriteLine(item);
                        };
                        break;
                    case "Update":
                        s_dal!.Engineer.Update(createEngineer());
                        break;
                    case "Delete":
                        Console.WriteLine("enter engineer's id");
                        s_dal!.Engineer.Delete(Convert.ToInt32(Console.ReadLine()));
                        break;
                    default:
                        Console.WriteLine("you entered worng choose");
                        break;
                }


            } while (choose != "Exit");
        }

        /// <summary>
        /// create new engineer entity recording to the input data.
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>

        private static Dependence createDependence(int id = 0000)
        {
            int dept_id;
            int pending_task_id;
            Console.WriteLine("Enter Pending IDTask id:");
            pending_task_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter pervious task id:");
            dept_id = Convert.ToInt32(Console.ReadLine());
            return new Dependence(id, pending_task_id, dept_id);
        }

        /// <summary>
        /// managing the dependencer's entity menu.
        /// </summary>
        public static void dependenceMenu()
        {
            string? choose;
            do
            {
                Console.WriteLine("Enter method choice: (Exit, Create, Read, ReadAll, Update, Delete)");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "Exit":
                        break;
                    case "Create":
                        s_dal!.Dependence.Create(createDependence());
                        break;
                    case "Read":
                        Console.WriteLine("Enter id");
                        Console.WriteLine(s_dal!.Dependence.Read(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "ReadAll":
                        foreach (var item in s_dal!.Dependence.ReadAll())
                        {
                            Console.WriteLine($"task id: {item.IDPendingTask}  pervious task id: {item.IDPreviousTask}");
                        };
                        break;
                    case "Update":
                        Console.WriteLine("Enter dependence's id");
                        s_dal!.Dependence.Update(createDependence(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "Delete":
                        Console.WriteLine("Enter id");
                        s_dal!.Dependence.Delete(Convert.ToInt32(Console.ReadLine()));
                        break;
                    default:
                        Console.WriteLine("you entered worng choose");
                        break;
                }
            } while (choose != "Exit");
        }
        /// <summary>
        /// managing the task's entity menu
        /// </summary>
        public static void generalMenue()
        {
            int choose;
            do
            {
                Console.WriteLine("Enter entyty choice: (1-task, 2-engineer, 3-dependence)");
                choose = (Convert.ToInt32(Console.ReadLine()));
                switch (choose)
                {
                    case 1:
                        taskMenu();
                        break;
                    case 2:
                        engineerMenu();
                        break;
                    case 3:
                        dependenceMenu();
                        break;
                    default:
                        break;
                }
            } while (choose != 0);
        }
    }
}

