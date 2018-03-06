namespace CodingameProject.Source.ObjectOrientedTraining
{
    public interface IAccountState
    {
        IAccountState Deposit();
        IAccountState Withdraw();
        IAccountState Freeze();
        IAccountState Close();
        IAccountState Verify();
    }
}