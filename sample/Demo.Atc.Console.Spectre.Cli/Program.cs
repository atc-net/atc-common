using System.Threading.Tasks;
using Atc.Console.Spectre.Factories;
using Atc.Console.Spectre.Logging;
using Demo.Atc.Console.Spectre.Cli.Commands;
using Microsoft.Extensions.Configuration;

namespace Demo.Atc.Console.Spectre.Cli
{
    public static class Program
    {
        public static Task<int> Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            var consoleLoggerConfiguration = new ConsoleLoggerConfiguration();
            configuration.GetSection("ConsoleLogger").Bind(consoleLoggerConfiguration);

            var serviceCollection = ServiceCollectionFactory.Create(consoleLoggerConfiguration);
            var app = CommandAppFactory.Create(serviceCollection);
            app.Configure(config =>
            {
                config.AddCommand<HelloCommand>("hello")
                    .WithDescription("Say hello")
                    .WithExample(new[] { "hello Phil" })
                    .WithExample(new[] { "hello Phil --count 4" });

                config.AddCommand<LogCommand>("log")
                    .WithDescription("Write a log message")
                    .WithExample(new[] { "log Hello world" })
                    .WithExample(new[] { "log Hello world --logLevel Trace" })
                    .WithExample(new[] { "log Hello world --logLevel Debug" })
                    .WithExample(new[] { "log Hello world --logLevel Information" })
                    .WithExample(new[] { "log Hello world --logLevel Warning" })
                    .WithExample(new[] { "log Hello world --logLevel Error" })
                    .WithExample(new[] { "log Hello world --logLevel Critical" });
            });

            return app.RunAsync(args);
        }
    }
}