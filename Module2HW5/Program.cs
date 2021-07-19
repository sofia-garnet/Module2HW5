using System;
using Microsoft.Extensions.DependencyInjection;
using Module2HW5.Abstraction;

namespace Module2HW5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<ILogger, Logger>()
                .AddTransient<Actions>()
                .AddTransient<Starter>().BuildServiceProvider();
            var starter = serviceProvider.GetService<Starter>();
            starter.Run();
        }
    }
}