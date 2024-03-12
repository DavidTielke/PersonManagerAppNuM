using System.Security.Authentication.ExtendedProtection;
using ConsoleClient.CrossCutting;
using ConsoleClient.Data;
using ConsoleClient.Logic;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace ConsoleClient.UI
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
            services.AddTransient<IFileStorer, FileLoader>(); // Überprüfe, ob FileLoader wirklich IFileStorer implementiert
            services.AddTransient<IPersonDataValidator, PersonDataValidator>();
            services.AddSingleton<IConfigurator, Configurator>();

            var kernel = services.BuildServiceProvider();

            var config = kernel.GetService<IConfigurator>();
            config.Set("AgeTreshold", 18);

            var manager = kernel.GetService<IPersonManager>();


            var adults = manager.GetAllAdults();
            Console.WriteLine($"### ERWACHSENE ({adults.Count})###");
            adults.ForEach(a => Console.WriteLine(a.Name));

            var children = manager.GetAllChildren();
            Console.WriteLine($"### Kinder ({children.Count})###");
            children.ForEach(c => Console.WriteLine(c.Name));
        }
    }
}
