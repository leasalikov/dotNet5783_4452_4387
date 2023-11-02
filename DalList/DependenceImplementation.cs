namespace Dal;
using DalApi;
using DO;
using System.Collections.Generic;

public class DependenceImplementation : IDependence
{
    public int Create(Dependence item)
    {
        foreach (Engineer engineer in DataSource.Engineers)
            if (engineer.ID == item.ID)
                throw new Exception($"Engineer whith ID {item.ID} is exist");
        DataSource.Engineers.Add(item);
        return item.ID;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Dependence? Read(int id)
    {
        throw new NotImplementedException();
    }

    public List<Dependence> ReadAll()
    {
        throw new NotImplementedException();
    }

    public void Update(Dependence item)
    {
        throw new NotImplementedException();
    }
}
