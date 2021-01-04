using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Net_Core_Console_Dependency_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = BuildContainer(args);

            var instance = host.Services.GetRequiredService<Foo>();

            Console.WriteLine(instance.Env);

            Console.ReadLine();
        }

        static IHost BuildContainer(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(x =>
                {
                    x.AddTransient<Foo>();
                })
                .Build();
        }
    }

    public class Foo
    {
        private readonly IHostEnvironment _env;
        public Foo(IHostEnvironment env)
        {
            _env = env;
        }

        public string Env => _env.EnvironmentName;
    }
}


