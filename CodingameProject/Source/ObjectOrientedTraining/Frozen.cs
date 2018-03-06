using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    internal class Frozen : IFreezable
    {
        private Action<string> OnUnfreeze { get; }

        public Frozen(Action<string> onUnfreeze)
        {
            OnUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit()
        {
            OnUnfreeze("I'm unfreezed.");
            return new Active(OnUnfreeze);
        }

        public IFreezable Withdraw()
        {
            OnUnfreeze("I'm unfreezed.");
            return new Active(OnUnfreeze);
        }

        public IFreezable Freeze() => this;
    }
}