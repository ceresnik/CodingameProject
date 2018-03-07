using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    class NotVerified : IAccountState
    {
        private Action<string> OnUnfreeze { get; }

        public NotVerified(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            return this;
        }

        public IAccountState Withdraw(Action removeFromBalance) => this;

        public IAccountState Freeze() => this;

        public IAccountState Close() => new Closed();

        public IAccountState Verify() => new Active(OnUnfreeze);
    }
}