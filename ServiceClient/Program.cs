
using System.ComponentModel;
using Backend.Data.DatabaseStorage;
using Backend.Data.FileStorage;
using Backend.Logic.PersonManagement;
using Castle.DynamicProxy;
using ConsoleClient.CrossCutting;
using CrossCutting.Proxies.Logging;
using Microsoft.AspNetCore.OData;
using ServiceClient.Extensions;
using ServiceClient.Middlewares;

namespace ServiceClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddOData(o =>
            {
                o.Select().Filter().SetMaxTop(2).OrderBy().Count();
            });
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<ProxyGenerator>();
            builder.Services.AddSingleton<IInterceptor, LoggingInterceptor>();

            builder.Services.AddProxiedTransient<IPersonManager, PersonManager>();
            builder.Services.AddProxiedTransient<IPersonRepository, PersonRepository>();
            builder.Services.AddProxiedTransient<IPersonConverter, PersonConverter>();
            builder.Services.AddProxiedTransient<IPersonParser, PersonParser>();
            builder.Services.AddProxiedTransient<IFileStorer, FileStorer>();
            builder.Services.AddProxiedTransient<IPersonInsertDataValidator, PersonInsertDataValidator>();
            builder.Services.AddProxiedTransient<IPersonAddLogicValidator, PersonAddLogicValidator>();
            builder.Services.AddSingleton<IConfigurator, Configurator>();

            var app = builder.Build();

            var config = app.Services.GetService<IConfigurator>();
            config.Set("AgeTreshold", 18);
            config.Set("CsvSeparator", ",");
            config.Set("DataPath", "data.csv");

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseMiddleware<ValidationExceptionMiddleware>();

            app.MapControllers();

            app.Run();
        }
    }
}
