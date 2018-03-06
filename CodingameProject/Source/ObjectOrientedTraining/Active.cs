using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    class Active : IFreezable
    {
        private Action<string> OnUnfreeze { get; }

        public Active(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit() => this;

        public IFreezable Withdraw() => this;

        public IFreezable Freeze() => new Frozen(OnUnfreeze);
    }
}