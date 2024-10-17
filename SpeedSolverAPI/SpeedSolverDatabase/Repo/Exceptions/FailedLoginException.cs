namespace SpeedSolverDatabase.Repo.Exceptions
{
    public class FailedLoginException: Exception
    {
        public FailedLoginException() : base("Failed login. Wrong credentials") { }
    }
}
