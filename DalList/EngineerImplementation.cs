namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class EngineerImplementation : IEngineer
{
    /// <summary>
    /// The function creates a new engineer and returns his ID
    /// </summary>
    public int Create(Engineer item)
    {
        foreach (Engineer engineer in DataSource.Engineers)
            if (engineer.ID == item.ID)
                throw new Exception($"Engineer whith ID {item.ID} is exist");
        DataSource.Engineers.Add(item);
        return item.ID;
    }
    /// <summary>
    /// The function delete an engineer 
    /// </summary>
    public void Delete(int id)
    {
        Engineer engineer = DataSource.Engineers.Find(item => item.ID == id)??
            throw new Exception($"Engineer whith ID {id} does not exist");
        DataSource.Engineers.Remove(engineer);
    }
    /// <summary>
    /// The function read an engineer and returns him
    /// </summary>
    public Engineer? Read(int id)
    {
        Engineer? engineer = DataSource.Engineers.Find(item => item.ID == id);
        return engineer;
    }
    /// <summary>
    /// The function read all the engineers and returns them
    /// </summary>
    public List<Engineer> ReadAll()
    {
        return new List<Engineer>(DataSource.Engineers);
    }
    /// <summary>
    /// The function updates the ditals of an engineer
    /// </summary>
    public void Update(Engineer item)
    {
        Engineer engineer = DataSource.Engineers.Find(item1 => item1.ID == item.ID) ??
           throw new Exception($"Engineer whith ID {item.ID} does not exist");
        DataSource.Engineers.Remove(engineer);
        DataSource.Engineers.Add(item);
    }
}