namespace StartupBusiness.Core.Exceptions
{
    public class DbExistingDataExeception : Exception
    {
        public DbExistingDataExeception(string message) : base(message) { }
    }
}
