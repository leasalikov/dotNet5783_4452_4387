﻿namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class TaskImplementation : ITask
{
    /// <summary>
    /// The function creates a new task and returns its serial number
    /// </summary>
    public int Create(Task item)
    {
        int newId = DataSource.Config.NextTaskId;
        Task task = item with { ID = newId };
        DataSource.Tasks.Add(task);
        return newId;
    }
    /// <summary>
    /// The function delete a task 
    /// </summary>
    public void Delete(int id)
    {
        Task task = DataSource.Tasks.Find(item => item.ID == id) ??
           throw new Exception($"Task whith ID {id} does not exist");
        DataSource.Tasks.Remove(task);
    }
    /// <summary>
    /// The function read a task and returns him
    /// </summary>
    public Task? Read(int id)
    {
        Task? task = DataSource.Tasks.Find(item => item.ID == id);
        return task;
    }
    /// <summary>
    /// The function read all the tasks and returns them
    /// </summary>
    public List<Task> ReadAll()
    {
        return new List<Task>(DataSource.Tasks);
    }
    /// <summary>
    /// The function updates the ditals of an task
    /// </summary>
    public void Update(Task item)
    {
        Task task = DataSource.Tasks.Find(item1 => item1.ID == item.ID) ??
           throw new Exception($"Task whith ID {item.ID} does not exist");
        DataSource.Tasks.Remove(task);
        DataSource.Tasks.Add(item);
    }
}