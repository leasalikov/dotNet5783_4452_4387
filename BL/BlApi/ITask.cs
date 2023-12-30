﻿namespace BlApi;

public interface ITask
{
    public IEnumerable<BO.Task> ReadAll();
    public BO.Task? Read(int id);
    public void add(BO.Task task);
    public void Update(BO.Task task);
    public void Delete(int id);

}
