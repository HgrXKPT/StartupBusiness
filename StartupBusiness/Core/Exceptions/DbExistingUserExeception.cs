namespace StartupBusiness.Core.Exceptions
{
    public class DbExistingUserExeception : Exception
    {
        public DbExistingUserExeception(string message) : base(message) { }
    }
}
