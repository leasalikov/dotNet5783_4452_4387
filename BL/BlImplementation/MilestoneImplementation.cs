
namespace BlImplementation;
using BlApi;

internal class MilestoneImplementation : IMilestone
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public BO.Milestone ReadAll(int id)
    {
        throw new NotImplementedException();
    }

    public BO.Milestone Update(int id)
    {
        throw new NotImplementedException();
    }
}
