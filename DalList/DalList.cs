﻿namespace Dal;
using DalApi;

sealed public class DalList : IDal
{
    public IEngineer Engineer => new EngineerImplementation();

    public ITask Task => new TaskImplementation();

    public IDependence Dependence => new DependenceImplementation();
}