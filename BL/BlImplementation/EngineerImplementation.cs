
namespace BlImplementation;
using BlApi;
using System.Security.Cryptography;
using System.Xml.Linq;

internal class EngineerImplementation : IEngineer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

     public int Create(BO.Engineer boEngineer)
    {
        if(boEngineer.ID <= 0 || string.IsNullOrEmpty(boEngineer.Name) || boEngineer.PriceOfHour > 0 || string.IsNullOrEmpty(boEngineer.Email))
        {
            throw new NotImplementedException();
        }
        DO.Engineer doEngineer = new DO.Engineer { ID = boEngineer.ID, FName = boEngineer.Name, Email = boEngineer.Email, EngineerLevel = (DO.EngineerLevelEnum)boEngineer.EngineerLevel, PriceOfHour = boEngineer.PriceOfHour };
        try
        {
            _dal.Engineer.Create(doEngineer);
            return doEngineer.ID;
        }
        catch {
            return 0;
        }
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Engineer? Read(int id)
    {
        try
        {
            DO.Engineer? myEngineer = _dal.Engineer.ReadAll().First(e => e.ID == id);
            if (myEngineer == null)
            {
                throw new InvalidOperationException();//חריגה שאין מתכנת עם הID שהתקבל
            }
            return DOToBO(myEngineer);
        }
        catch {
            /////////////////////??????????????????????????
            return null;
        }
    }

    public IEnumerable<BO.Engineer> ReadAll()
    {
        return from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
                select DOToBO(doEngineer);
    }

    public void Update(BO.Engineer engineer)
    {
        throw new NotImplementedException();
    }

    private BO.Engineer DOToBO(DO.Engineer doEngineer)
    {
        return new BO.Engineer
        {
            ID = doEngineer.ID,
            Name = doEngineer.FName,
            Email = doEngineer.Email,
            EngineerLevel = (BO.EngineerLevelEnum)doEngineer.EngineerLevel,
            PriceOfHour = doEngineer.PriceOfHour,
            Task = (from DO.Task doTask in _dal.Task.ReadAll() where doTask.IDEngineer == doEngineer.ID select new BO.TaskIdNickname() { ID = doTask.ID, Nickname = doTask.Nickname }).First()
        };
    }
}
