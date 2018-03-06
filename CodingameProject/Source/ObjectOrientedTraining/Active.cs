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

        public IAccountState Deposit() => this;

        public IAccountState Withdraw() => this;

        public IAccountState Freeze() => new Frozen(OnUnfreeze);

        public IAccountState Close() => new Closed(OnUnfreeze);

        public IAccountState Verify() => new Active(OnUnfreeze);
    }
}