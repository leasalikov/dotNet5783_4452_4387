
using DalApi;
using DO;

namespace Dal;

internal class EngineerImplementation : IEngineer
{
    /// <summary>
    /// The function creates a new engineer and returns his ID
    /// </summary>
    public int Create(Engineer item)
    {
        List<Engineer> ls = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        foreach (Engineer engineer in ls)
            if (engineer.ID == item.ID)
                throw new DalDoesNotExistException($"Engineer with ID {item.ID} exist");
        ls.Add(item);
        XMLTools.SaveListToXMLSerializer(ls, "engineers");
        return item.ID;
    }

    /// <summary>
    /// The function delete an engineer 
    /// </summary>
    public void Delete(int id)
    {
        List<Engineer> ls = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer engineer = ls.Where(item => item.ID == id).First() ??
           throw new DalDoesNotExistException($"Engineer with ID {id} does not exist");
        ls.Remove(engineer);
        XMLTools.SaveListToXMLSerializer(ls, "engineers");
    }

    /// <summary>
    /// The function read an engineer and returns him
    /// </summary>
    public Engineer? Read(Func<Engineer, bool> filter)
    {
        List<Engineer> ls = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer engineer = ls.Where(filter).First() ??
            throw new DalDoesNotExistException($"Does not exist");
        return engineer;
    }

    /// <summary>
    /// The function reads a engineer according to the id and returns him
    /// </summary>
    public Engineer? Read(int id)
    {
        List<Engineer> ls = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer engineerFind = ls.Where(s => s!.ID == id).First() ??
                       throw new DalDoesNotExistException($"Engineer with ID {id} does not exist");
        return engineerFind;
    }

    /// <summary>
    /// The function read all the engineers and returns them
    /// </summary>
    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)
    {
        List<Engineer> ls = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        if (filter == null)
            return ls.Select(item => item);
        else
            return ls.Where(filter);
    }

    /// <summary>
    /// The function updates the ditals of an engineer
    /// </summary>
    public void Update(Engineer item)
    {
        List<Engineer> ls = XMLTools.LoadListFromXMLSerializer<Engineer>("engineers");
        Engineer engineer = ls.Where(item1 => item1.ID == item.ID).First() ??
            throw new DalDoesNotExistException($"Engineer with ID {item.ID} does not exist");
        ls.Remove(engineer);
        ls.Add(item);
        XMLTools.SaveListToXMLSerializer(ls, "engineers");
    }
}
