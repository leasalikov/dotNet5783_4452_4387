
using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;

internal class DependenceImplementation : IDependence
{
    public int Create(Dependence item)
    {
        int newId = Config.NextDependnceId;
        Dependence dependence = item with { ID = newId };
        //DataSource.Dependences.Add(dependence);
        StreamReader reader = new(FILEKALA);
        var l = (List<Kalah>?)xmlSerializer?.Deserialize(reader);
        return newId;
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Dependence? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Dependence? Read(Func<Dependence, bool> filter)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Dependence?> ReadAll(Func<Dependence, bool>? filter = null)
    {
        throw new NotImplementedException();
    }

    public void Update(Dependence item)
    {
        throw new NotImplementedException();
    }
}
