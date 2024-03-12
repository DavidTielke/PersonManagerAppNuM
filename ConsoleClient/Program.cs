using System.Security.Authentication.ExtendedProtection;
using Backend.Data.DatabaseStorage;
using Backend.Data.FileStorage;
using Backend.Logic.PersonManagement;
using ConsoleClient.CrossCutting;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace ConsoleClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IPersonManager, PersonManager>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IPersonConverter, PersonConverter>();
            services.AddTransient<IPersonParser, PersonParser>();
            services.AddTransient<IFileStorer, FileStorer>(); // Überprüfe, ob FileStorer wirklich IFileStorer implementiert
            services.AddTransient<IPersonDataValidator, PersonDataValidator>();
            services.AddSingleton<IConfigurator, Configurator>();

            var kernel = services.BuildServiceProvider();

            var config = kernel.GetService<IConfigurator>();
            config.Set("AgeTreshold", 18);
            config.Set("CsvSeparator", ",");
            config.Set("DataPath", "data.csv");

            var manager = kernel.GetService<IPersonManager>();


            var adults = manager.GetAllAdults();
            Console.WriteLine($"### ERWACHSENE ({adults.Count()})###");
            adults.ToList().ForEach(a => Console.WriteLine(a.Name));

            var children = manager.GetAllChildren();
            Console.WriteLine($"### Kinder ({children.Count()})###");
            children.ToList().ForEach(c => Console.WriteLine(c.Name));
        }
    }
}
