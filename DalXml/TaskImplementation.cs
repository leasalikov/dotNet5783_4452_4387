namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Threading.Tasks;
using System.Xml.Linq;
internal class TaskImplementation : ITask
{
    const string s_tasks = "tasks";
    /// <summary>
    ///  Gets an task.
    /// </summary>
    /// <param name="e"></param>
    /// <returns></returns>
    static DO.Task? GetTask(XElement? task)
    {
        if (task == null)
            return null;
        return task.ToIntNullable("ID") is null ? null : new DO.Task()
        {
            ID = (int)task.Element("ID")!,
            Description = (string)task.Element("Description")!,
            Nickname = (string)task.Element("Nickname")!,
            Milestone = (bool)task.Element("Milestone")!,
            Production = (DateTime)task.Element("Production")!,
            Start = (DateTime)task.Element("Start")!,
            AcualStartNate = (DateTime)task.Element("AcualStartNate")!,
            longTime = (int)task.Element("longTime")!,
            deadline = (DateTime)task.Element("deadline")!,
            AcualEndNate = (DateTime)task.Element("AcualEndNate")!,
            Product = (string)task.Element("Product")!,
            Remaeks = (string)task.Element("Remaeks")!,
            IDEngineer = (int)task.Element("IDEngineer")!,
            //Difficulty = XMLTools.ToEnumNullable<EngineerExperience>(task, "Difficulty"),
            //Difficulty = XMLTools.ToEnumNullable<Task>(task ,"Difficulty")
        };
    }

    /// <summary>
    /// Creates an task element.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    static IEnumerable<XElement> CreateTaskElement(DO.Task task)
    {
        yield return new XElement("ID", task.ID);
        if (task.Description is not null)
            yield return new XElement("Description", task.Description);
        if (task.Description is not null)
            yield return new XElement("Nickname", task.Nickname);
        if (task.Description is not null)
            yield return new XElement("Production", task.Production);
        if (task.Description is not null)
            yield return new XElement("Start", task.Start);
        if (task.Description is not null)
            yield return new XElement("AcualStartNate", task.AcualStartNate);
        if (task.Description is not null)
            yield return new XElement("longTime", task.longTime);
        if (task.Description is not null)
            yield return new XElement("deadline", task.deadline);
        if (task.Description is not null)
            yield return new XElement("AcualEndNate", task.AcualEndNate);
        if (task.Description is not null)
            yield return new XElement("Product", task.Product);
        if (task.Description is not null)
            yield return new XElement("Remaeks", task.Remaeks);
        if (task.Description is not null)
            yield return new XElement("IDEngineer", task.IDEngineer);
    }
    /// <summary>
    /// finds an task by Id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public DO.Task? Read(int id) =>
         GetTask(XMLTools.LoadListFromXMLElement(s_tasks)?.Elements()
        .FirstOrDefault(st => st.ToIntNullable("ID") == id) ?? null);

    //fix to: throw new DalMissingIdException(id);
    //?? throw new DalDoesNotExistException($"Task with ID={id} does not exist"))!;

    /// <summary>
    /// finds an task by specific attribute using filter.
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    /// <exception cref="DalDoesNotExistException"></exception>
    public DO.Task? Read(Func<DO.Task, bool> filter) =>
        XMLTools.LoadListFromXMLElement(s_tasks).Elements().Select(s => GetTask(s)).Where(filter!).FirstOrDefault() ?? null;

    // fix to: throw new DalMissingIdException(id);
    //?? throw new DalDoesNotExistException($"Task with such filter does not exist")!;

    /// <summary>
    /// returns all tasks
    /// </summary>
    /// <param name="filter"></param>
    /// <returns></returns>
    public IEnumerable<DO.Task?> ReadAll(Func<DO.Task, bool>? filter = null) =>
        filter is null
        ? XMLTools.LoadListFromXMLElement(s_tasks).Elements().Select(s => GetTask(s))
        : XMLTools.LoadListFromXMLElement(s_tasks).Elements().Select(s => GetTask(s)).Where(filter!);

    /// <summary>
    /// creates a new task.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    /// <exception cref="DalAlreadyExistsException"></exception>
    public int Create(DO.Task task)
    {
        XElement engineersRootElem = XMLTools.LoadListFromXMLElement(s_tasks);
        if (XMLTools.LoadListFromXMLElement(s_tasks)?.Elements()
            .FirstOrDefault(st => st.ToIntNullable("ID") == task.ID) is not null)
            // fix to: throw new DalMissingIdException(id);;
            throw new DalAlreadyExistsException("id already exist");
        engineersRootElem.Add(new XElement("Engineer", CreateTaskElement(task)));
        XMLTools.SaveListToXMLElement(engineersRootElem, s_tasks);
        return task.ID;
    }

    /// <summary>
    /// deletes an task from data using a list.
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="DalDoesNotExistException"></exception>
    public void Delete(int id)
    {
        XElement engineersRootElem = XMLTools.LoadListFromXMLElement(s_tasks);

        (engineersRootElem.Elements()
            // fix to: throw new DalMissingIdException(id);
            .FirstOrDefault(st => (int?)st.Element("ID") == id) ?? throw new DalDoesNotExistException("missing id"))
            .Remove();

        XMLTools.SaveListToXMLElement(engineersRootElem, s_tasks);
    }
    /// <summary>
    /// updates an task
    /// </summary>
    /// <param name="engineer"></param>
    public void Update(DO.Task task)
    {
        Delete(task.ID);
        Create(task);
    }
}
