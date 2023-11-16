namespace Dal;
using DalApi;
using DO;
using System;
using System.Collections.Generic;
using System.Linq;

internal class EngineerImplementation : IEngineer
{
    /// <summary>
    /// The function creates a new engineer and returns his ID
    /// </summary>
    public int Create(Engineer item)
    {
        foreach (Task engineer in DataSource.Engineers)
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
        Task engineer = DataSource.Engineers.Where(item => item.ID == id).First() ??
            throw new Exception($"Engineer whith ID {id} does not exist");
        DataSource.Engineers.Remove(engineer);
    }
    /// <summary>
    /// The function read an engineer and returns him
    /// </summary>
    public Engineer? Read(Func<Engineer, bool> filter)
    {
        if (filter != null)
        {
            return from item in DataSource.Engineers
                   where filter(item)
                   select item;
        }
        return from item in DataSource.Engineers
               select item;
    }
    /// <summary>
    /// The function read all the engineers and returns them
    /// </summary>
    public IEnumerable<Engineer?> ReadAll(Func<Engineer, bool>? filter = null)
    {
        if (filter != null)
        {
            return (from item in DataSource.Engineers
                   where filter(item)
                   select item);
        }
        return (from item in DataSource.Engineers
               select item);
    }
    /// <summary>
    /// The function updates the ditals of an engineer
    /// </summary>
    public void Update(Engineer item)
    {
        Task engineer = DataSource.Engineers.Where(item1 => item1.ID == item.ID).First() ??
           throw new Exception($"Engineer whith ID {item.ID} does not exist");
        DataSource.Engineers.Remove(engineer);
        DataSource.Engineers.Add(item);
    }
}