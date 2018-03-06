using System;

namespace CodingameProject.Source.ObjectOrientedTraining
{
    internal class Frozen : IFreezable
    {
        private readonly Action<string> onUnfreeze;

        public Frozen(Action<string> onUnfreeze)
        {
            this.onUnfreeze = onUnfreeze;
        }

        public IFreezable Deposit()
        {
            onUnfreeze("I'm unfreezed.");
            return new Active(onUnfreeze);
        }

        public IFreezable Withdraw()
        {
            onUnfreeze("I'm unfreezed.");
            return new Active(onUnfreeze);
        }

        public IFreezable Freeze()
        {
            return this;
        }
    }
}