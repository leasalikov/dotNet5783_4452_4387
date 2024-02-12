using BO;

namespace BlApi;

public interface ITask
{
    public IEnumerable<BO.Task> ReadAll(BO.Status status = Status.All);
    public BO.Task? Read(int id);
    public void Create(BO.Task task);
    public void Update(BO.Task task);
    public void Delete(int id);

}
