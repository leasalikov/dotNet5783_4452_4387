namespace BlApi;

public interface IEngineer
{
    public IEnumerable<BO.Engineer> ReadAll();
    public BO.Engineer? Read(int id);
    public void Create(BO.Engineer engineer);
    public void Update(BO.Engineer engineer);
    public void Delete(int id);

}
