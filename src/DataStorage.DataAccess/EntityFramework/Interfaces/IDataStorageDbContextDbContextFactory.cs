namespace DataStorage.DataAccess.EntityFramework.Interfaces
{
    public interface IDataStorageDbContextDbContextFactory
    {
        DataStorageDbContext CreateDbContext();
    }
}
