using System;

namespace CodingameProject.Source.ObjectOrientedTraining.StatePattern
{
    public interface IAccountState
    {
        IAccountState Deposit(Action addToBalance);
        IAccountState Withdraw(Action removeFromBalance);
        IAccountState Freeze();
        IAccountState Close();
        IAccountState Verify();
    }
}