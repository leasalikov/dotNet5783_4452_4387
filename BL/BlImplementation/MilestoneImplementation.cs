﻿namespace BlImplementation;
using BlApi;
using BO;
using DO;

internal class MilestoneImplementation : IMilestone
{
    private DalApi.IDal _dal = DalApi.Factory.Get;

    public Milestone ReadAll(int id)
    {
        throw new NotImplementedException();
    }

    public Milestone Update(int id)
    {
        throw new NotImplementedException();
    }
    //public BO.Milestone ReadAll(int id)
    //{
    //    _dal.Dependence.Read(id){

    //    };
    //    throw new NotImplementedException();
    //}

    //public BO.Milestone Update(int id)
    //{
    //    throw new NotImplementedException();
    //}
}
