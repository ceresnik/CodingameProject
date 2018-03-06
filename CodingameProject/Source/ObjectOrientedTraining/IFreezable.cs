namespace CodingameProject.Source.ObjectOrientedTraining
{
    interface IFreezable
    {
        IFreezable Deposit();
        IFreezable Withdraw();
        IFreezable Freeze();
    }
}