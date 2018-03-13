using System;

namespace CodingameProject.Source.ObjectOrientedTraining.StatePattern
{
    internal class Frozen : IAccountState
    {
        private Action<string> OnUnfreeze { get; }

        public Frozen(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IAccountState Deposit(Action addToBalance)
        {
            addToBalance();
            OnUnfreeze("I'm unfreezed.");
            return new Active(OnUnfreeze);
        }

        public IAccountState Withdraw(Action removeFromBalance)
        {
            removeFromBalance();
            OnUnfreeze("I'm unfreezed.");
            return new Active(OnUnfreeze);
        }

        public IAccountState Freeze() => this;

        public IAccountState Close() => new Closed();

        public IAccountState Verify() => new Active(OnUnfreeze);
    }
}