﻿namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;
using System.Linq;
internal class DependenceImplementation : IDependence
{
    /// <summary>
    /// The function creates a new dependence and returns its serial number
    /// </summary>
    public int Create(Dependence item)
    {
        int newId = DataSource.Config.NextTaskId;
        Dependence dependence = item with { ID = newId };
        DataSource.Dependences.Add(dependence);
        return newId;
    }
    /// <summary>
    /// The function delete a dependence 
    /// </summary>
    public void Delete(int id)
    {
        Dependence dependence = DataSource.Dependences.Where(item => item.ID == id).First() ??
           throw new Exception($"Dependence whith ID {id} does not exist");
        DataSource.Dependences.Remove(dependence);
    }
    /// <summary>
    /// The function read a dependence and returns him
    /// </summary>
    public Dependence? Read(Func<Dependence, bool> filter)
    {
        if (filter != null)
        {
            return (Dependence?)(from item in DataSource.Dependences
                                where filter(item)
                                select item);
        }
        return (Dependence?)(from item in DataSource.Dependences
                            select item);
    }
    /// <summary>
    /// The function read all the dependences and returns them
    /// </summary>
    public IEnumerable<Dependence?> ReadAll(Func<Dependence, bool>? filter)
    {
        if (filter != null)
        {
            return from item in DataSource.Dependences
                    where filter(item)
                    select item;
        }
        return from item in DataSource.Dependences
                select item;
    }
    /// <summary>
    /// The function updates the ditals of a dependence
    /// </summary>
    public void Update(Dependence item)
    {
        Dependence dependence = DataSource.Dependences.Where(item1 => item1.ID == item.ID).First() ??
           throw new Exception($"Dependence whith ID {item.ID} does not exist");
        DataSource.Dependences.Remove(dependence);
        DataSource.Dependences.Add(item);
    }
}
