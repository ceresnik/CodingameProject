using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    class Active : IAccountState
    {
        private Action<string> OnUnfreeze { get; }

        public Active(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action AddToBalance)
        {
            AddToBalance();
            return this;
        }

        public IAccountState Withdraw(Action RemoveFromBalance)
        {
            RemoveFromBalance();
            return this;
        }

        public IAccountState Freeze() => new Frozen(OnUnfreeze);

        public IAccountState Close() => new Closed();

        public IAccountState Verify() => this;
    }
}