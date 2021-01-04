using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;

namespace Net_Core_Console_Dependency_Injection.UsingServiceProvider
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = BuildContainer(args);

            var instance = container.GetRequiredService<Foo>();

            Console.WriteLine(instance.Env);

            Console.ReadLine();
        }

        static ServiceProvider BuildContainer(string[] args)
        {
            var services = new ServiceCollection();

            services.AddTransient<Foo>();

            services.AddSingleton<IHostEnvironment, HostingEnvironment>();

            return services.BuildServiceProvider();

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

