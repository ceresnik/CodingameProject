using System;

namespace CodingameProject.Source.ObjectOrientedTraining.StatePattern
{
    class Closed : IAccountState
    {
        public IAccountState Deposit(Action AddToBalance) => this;

        public IAccountState Withdraw(Action RemoveFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState Close() => this;

        public IAccountState Verify() => this;
    }
}