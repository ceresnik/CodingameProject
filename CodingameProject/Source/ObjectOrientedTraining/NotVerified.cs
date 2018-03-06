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

        public IAccountState Deposit()
        {
            return this;
        }

        public IAccountState Withdraw()
        {
            return this;
        }

        public IAccountState Freeze()
        {
            return this;
        }

        public IAccountState Close()
        {
            return new Closed(OnUnfreeze);
        }

        public IAccountState Verify()
        {
            return new Active(OnUnfreeze);
        }
    }
}