
namespace BlImplementation;
using BlApi;

internal class EngineerImplementation : IEngineer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

     public int Create(BO.Engineer boEngineer)
    {

        throw new NotImplementedException();
    }
    public void Add(BO.Engineer engineer)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Engineer? Read(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<BO.Engineer> ReadAll()
    {
        _dal.Task.ReadAll();
        return (IEnumerable < BO.Engineer > ) from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
                select new BO.Engineer
                {
                    ID = doEngineer.ID,
                    Name = doEngineer.FName,
                    Email = doEngineer.Email,
                    EngineerLevel = (BO.EngineerLevelEnum)doEngineer.EngineerLevel,
                    PriceOfHour = doEngineer.PriceOfHour,
                    Task = (from DO.Task doTask in _dal.Task.ReadAll() where doTask.IDEngineer == doEngineer.ID select new BO.TaskIdNickname() { ID = doTask.ID, Nickname = doTask.Nickname }).First()
                };
    }

    public void Update(BO.Engineer engineer)
    {
        throw new NotImplementedException();
    }
}
