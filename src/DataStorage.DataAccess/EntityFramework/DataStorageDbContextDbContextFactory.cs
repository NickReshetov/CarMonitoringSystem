using System;
using DataStorage.DataAccess.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace DataStorage.DataAccess.EntityFramework
{
    public class DataStorageDbContextDbContextFactory : IDataStorageDbContextDbContextFactory, IDesignTimeDbContextFactory<DataStorageDbContext>
    {

        public DataStorageDbContext CreateDbContext()
        {
            return CreateDbContext(Array.Empty<string>());
        }

        public DataStorageDbContext CreateDbContext(string[] args)
        {
            var connectionString = GetConnectionString();

            var builder = new DbContextOptionsBuilder<DataStorageDbContext>();

            builder.UseInMemoryDatabase(connectionString);

            var context = new DataStorageDbContext(builder.Options);

            return context;
        }

        protected virtual string GetConnectionString()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("data-access-appsettings.json", optional: false)
                .Build();

            var connectionString = configuration.GetConnectionString("Database");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("Can't load connection string from data-access-appsettings.json");

            return connectionString;
        }
    }
}
