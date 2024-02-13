
namespace BlImplementation;

using System.Buffers.Text;
using BlApi;
using BO;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class EngineerImplementation : IEngineer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    /// <summary>
    /// The function attempts to add a new engineer to the database, throwing a specific exception if the engineer already exists
    /// </summary>
    public int Create(BO.Engineer boEngineer)
    {
        try
        {
            DO.Engineer doEngineer = BOToDO(boEngineer);
            return _dal.Engineer.Create(doEngineer);
        }
        catch (BlIncorrectDetails ex)
        {
            throw ex;
        }
        catch {
            throw new BO.BlAlreadyExistsException($"Engineer number {boEngineer.ID} exists");
        }
    }
    /// <summary>
    /// The function attempts to Delete a engineer to the database, throwing a specific exception if the engineer dos't exists
    /// </summary>
    public void Delete(int id)
    {
        try
        {
            if (_dal.Task.ReadAll().Any(task => task.IDEngineer == id))
            {
                throw new BO.EngineerHaveTask("There are tasks that rely on it");
            }
            _dal.Engineer.Delete(id);
        }
        catch(EngineerHaveTask ex)
        {
            throw ex;
        }
        catch
        {
            throw new BlDoesNotExistException($"Engineer id {id} dos't exist");
        }
    }
    /// <summary>
    /// The function fetches an engineer by ID from the database, converting it to a business object, or throws an exception if not found.
    /// </summary>

    public BO.Engineer? Read(int id)
    {
        try
        {
            DO.Engineer? myEngineer = _dal.Engineer.Read(id);
            return DOToBO(myEngineer);
        }
        catch {
            throw new BlDoesNotExistException($"Engineer id {id} dos't exist");
        }
    }
    /// <summary>
    /// The function retrieves all engineers from the database, filtering by level if specified, and returns them as business objects
    /// </summary>
    public IEnumerable<BO.Engineer> ReadAll(BO.EngineerLevelEnum level = EngineerLevelEnum.None)
    {
        if(level == EngineerLevelEnum.None)
        {
            return from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
                   select DOToBO(doEngineer);
        }
        return from DO.Engineer doEngineer in _dal.Engineer.ReadAll()
               where (BO.EngineerLevelEnum)doEngineer.EngineerLevel == level
               select DOToBO(doEngineer);
    }
    /// <summary>
    ///The function modifies an engineer in the database based on the provided business object, or throws an exception if the engineer doesn't exist
    /// </summary>
    public void Update(BO.Engineer boEngineer)
    {
        try
        {
            _dal.Engineer.Update(BOToDO(boEngineer));
        }
        catch (BlIncorrectDetails ex)
        {
            throw ex;
        }
        catch
        {
            throw new BlDoesNotExistException($"Engineer id {boEngineer.ID} dos't exist");
        }
    }
    /// <summary>
    /// The DOToBO function maps a data object representing an engineer to a corresponding business object, including related task information if available
    /// </summary>
    private BO.Engineer DOToBO(DO.Engineer doEngineer)
    {
        return new BO.Engineer
        {
            ID = doEngineer.ID,
            Name = doEngineer.Name,
            Email = doEngineer.Email,
            EngineerLevel = (BO.EngineerLevelEnum)doEngineer.EngineerLevel,
            PriceOfHour = doEngineer.PriceOfHour,
            Task = (from DO.Task doTask in _dal.Task.ReadAll()
                           where doTask.IDEngineer == doEngineer.ID
                           select new BO.TaskIdNickname() { ID = doTask.ID, Nickname = doTask.Nickname! }).FirstOrDefault()
        };
    }
    /// <summary>
    /// The BOToDO function converts a business object for an engineer to a data object, validating details and throwing an exception for any incorrect information
    /// </summary>
    private DO.Engineer BOToDO(BO.Engineer boEngineer)
    {
        if (boEngineer.ID <= 0 || string.IsNullOrEmpty(boEngineer.Name) || boEngineer.PriceOfHour < 35 || string.IsNullOrEmpty(boEngineer.Email))
        {
            throw new BlIncorrectDetails("The Detals are incorrect");
        }
        return new DO.Engineer { ID = boEngineer.ID, Name = boEngineer.Name, Email = boEngineer.Email, EngineerLevel = (DO.EngineerLevelEnum)boEngineer.EngineerLevel, PriceOfHour = boEngineer.PriceOfHour };
    }
}
