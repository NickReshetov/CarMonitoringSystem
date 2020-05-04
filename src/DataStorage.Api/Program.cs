using System;
using System.Collections.Generic;
using DataStorage.DataAccess.EntityFramework.Entities;
using DataStorage.DataAccess.EntityFramework.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace DataStorage.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args).Build();

            SeedDatabaseData(hostBuilder);

            hostBuilder.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseStartup<Startup>()
                        .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration.ReadFrom.Configuration(hostingContext.Configuration));
                });
        }

        private static void SeedDatabaseData(IHost host)
        {
            using var scope = host.Services.CreateScope();

            var dataStorageDbContextDbContextFactory =
                scope.ServiceProvider.GetService<IDataStorageDbContextDbContextFactory>();

            var context = dataStorageDbContextDbContextFactory.CreateDbContext();
            
            context.Companies.Add(new Company()
            {
                Id = Guid.Parse("ed136838-f3ac-45fd-8b41-d9e9e035f5fa"),
                Name = "Kalles Grustransporter AB",
                Address = "Cementvägen 8, 111 11 Södertälje",
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Id = Guid.Parse("9cfcf01d-2fc2-4421-ba92-161e26523ec7"),
                        CompanyId = Guid.Parse("ed136838-f3ac-45fd-8b41-d9e9e035f5fa"),
                        VinCode = "YS2R4X20005399401",
                        RegistrationNumber = "ABC123",
                        LastConnectionTime = DateTime.UtcNow
                    },
                    new Car()
                    {
                        Id = Guid.Parse("60d63d29-bbd5-415b-baf9-fbb30d1931ec"),
                        CompanyId = Guid.Parse("ed136838-f3ac-45fd-8b41-d9e9e035f5fa"),
                        VinCode = "VLUR4X20009048066",
                        RegistrationNumber = "GHI789",
                        LastConnectionTime = DateTime.UtcNow
                    },
                    new Car()
                    {
                        Id = Guid.Parse("f3010824-b306-4f47-9b4b-63e9f2df9dbb"),
                        CompanyId = Guid.Parse("ed136838-f3ac-45fd-8b41-d9e9e035f5fa"),
                        VinCode = "VLUR4X20009093588",
                        RegistrationNumber = "DEF456",
                        LastConnectionTime = DateTime.UtcNow
                    }
                }
            });

            context.Companies.Add(new Company()
            {
                Id = Guid.Parse("22e89d36-5502-4b36-818c-adaba4b12091"),
                Name = "Johans Bulk AB",
                Address = "Balkvägen 12, 222 22 Stockholm",
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Id = Guid.Parse("6d11f4ce-7f40-409a-b32d-4361623facd0"),
                        CompanyId = Guid.Parse("22e89d36-5502-4b36-818c-adaba4b12091"),
                        VinCode = "YS2R4X20005388011",
                        RegistrationNumber = "JKL012",
                        LastConnectionTime = DateTime.UtcNow
                    },
                    new Car()
                    {
                        Id = Guid.Parse("2d2acf5e-b851-4b82-b9fd-fc6d7e891a8a"),
                        CompanyId = Guid.Parse("22e89d36-5502-4b36-818c-adaba4b12091"),
                        VinCode = "YS2R4X20005387949",
                        RegistrationNumber = "MNO345",
                        LastConnectionTime = DateTime.UtcNow
                    }
                }
            });

            context.Companies.Add(new Company()
            {
                Id = Guid.Parse("12f6edef-bdf2-43ac-a4fa-b8ecb63ebd0d"),
                Name = "Haralds Värdetransporter AB",
                Address = "Budgetvägen 1, 333 33 Uppsala",
                Cars = new List<Car>()
                {
                    new Car()
                    {
                        Id = Guid.Parse("6af83221-c82f-4dd3-a347-10ed8c987024"),
                        CompanyId = Guid.Parse("12f6edef-bdf2-43ac-a4fa-b8ecb63ebd0d"),
                        VinCode = "YS2R4X20005387765",
                        RegistrationNumber = "PQR678",
                        LastConnectionTime = DateTime.UtcNow
                    },
                    new Car()
                    {
                        Id = Guid.Parse("9271d334-c22c-4f4f-a6d4-c33508669015"),
                        CompanyId = Guid.Parse("12f6edef-bdf2-43ac-a4fa-b8ecb63ebd0d"),
                        VinCode = "YS2R4X20005387055",
                        RegistrationNumber = "STU901",
                        LastConnectionTime = DateTime.UtcNow
                    }
                }
            });

            context.SaveChanges();

        }
    }
}
