using Dal;
using DalApi;
using DO;
using System.ComponentModel;
using System.Globalization;
using System.Reflection.Emit;
using System.Text.Json.Serialization;

namespace DalTest
{
    internal class Program
    {

        private static ITask? s_dalTask = new TaskImplementation();
        private static IEngineer? s_dalEngineer = new EngineerImplementation();
        private static IDependence? s_dalDependence = new DependenceImplementation();

        /// <summary>
        /// create new task entity recording to the input data
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static DO.Task create_task(int id = 0000)
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
        //DO.Task new_task = new(0, null, null, false, Production, Start, EstimatedCompletion, Final, null, null, null, IDEngineer, Difficulty);

        /// <summary>
        /// managing the task's entity menu.
        /// </summary>
        public static void task_menu()
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
                        s_dalTask!.Create(create_task());
                        break;
                    case "Read":
                        Console.WriteLine("enter task's id");
                        Console.WriteLine(s_dalTask!.Read(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "ReadAll":
                        foreach (var item in s_dalTask!.ReadAll())
                            Console.WriteLine(item);
                        break;
                    case "Update":
                        Console.WriteLine("Enter task's id");
                        s_dalTask!.Update(create_task(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "Delete":
                        Console.WriteLine("enter task's id");
                        s_dalTask!.Delete(Convert.ToInt32(Console.ReadLine()));
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

        private static DO.Engineer recept_engineer()
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
        public static void engineer_menu()
        {
            string? choose;
            do
            {
                Console.WriteLine("Enter method choice: (Exsit, Create,Read,ReadAll, Update, Delete)");
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "Exit":
                        break;
                    case "Create":
                        s_dalEngineer!.Create(recept_engineer());
                        break;
                    case "Read":
                        Console.WriteLine("enter engineer's id");
                        Console.WriteLine(s_dalEngineer!.Read(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "ReadAll":
                        foreach (var item in s_dalEngineer!.ReadAll())
                        {
                            Console.WriteLine(item);
                        };
                        break;
                    case "Update":
                        s_dalEngineer!.Update(recept_engineer());
                        break;
                    case "Delete":
                        Console.WriteLine("enter engineer's id");
                        s_dalEngineer!.Delete(Convert.ToInt32(Console.ReadLine()));
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

        private static DO.Dependence recept_dependence(int dept_id = 0000)
        {
            int task_id;
            int prev_task_id;
            Console.WriteLine("Enter task id:");
            task_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter pervious task id:");
            prev_task_id = Convert.ToInt32(Console.ReadLine());
            return new DO.Dependence(task_id, prev_task_id, dept_id);
        }

        /// <summary>
        /// managing the dependencer's entity menu.
        /// </summary>
        public static void dependence_menu()
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
                        s_dalDependence!.Create(recept_dependence());
                        break;
                    case "Read":
                        Console.WriteLine("Enter id");
                        Console.WriteLine(s_dalDependence!.Read(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "ReadAll":
                        foreach (var item in s_dalDependence!.ReadAll())
                        {
                            Console.WriteLine($"id: {item.ID}  task id: {item.ID}  pervious task id: {item.IDPreviousTask}");
                        };
                        break;
                    case "Update":
                        Console.WriteLine("Enter dependence's id");
                        s_dalDependence!.Update(recept_dependence(Convert.ToInt32(Console.ReadLine())));
                        break;
                    case "Delete":
                        Console.WriteLine("Enter id");
                        s_dalDependence!.Delete(Convert.ToInt32(Console.ReadLine()));
                        break;
                    default:
                        Console.WriteLine("you entered worng choose");
                        break;
                }
            } while (choose != "Exit");
        }
        public static void general_menue()
        {
            int choose;
            do
            {
                Console.WriteLine("Enter entyty choice: (1-task, 2-engineer, 3-dependence)");
                choose = (Convert.ToInt32(Console.ReadLine()));
                switch (choose)
                {
                    case 1:
                        task_menu();
                        break;
                    case 2:
                        engineer_menu();
                        break;
                    case 3:
                        dependence_menu();
                        break;
                    default:
                        break;
                }


            } while (choose != 0);
        }
        static void Main(string[] args)
        {
            try
            {
                general_menue();
                Initialization.Do(s_dalTask, s_dalEngineer, s_dalDependence);
            }
            catch (Exception error)
            {
                Console.WriteLine(error.ToString());
            }
        }
    }
}

