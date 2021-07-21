using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace MetaWeather.TestConsole
{
    class Program
    {
        private static IHost hosting;

        public static IHost Hosting => hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        public static IServiceProvider Services => Hosting.Services;

        // Создаем хост приложения и конфигурируем сервисы
        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        // Регистрируем все сервисы
        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddHttpClient<MetaWeatherClient>(client => client.BaseAddress = new Uri(host.Configuration["MetaWeather"]));
        }

        static async Task Main(string[] args)
        {
            using var host = Hosting;
            await host.StartAsync();

            var weather = Services.GetRequiredService<MetaWeatherClient>();

            var moscow = await weather.GetInfoByName("Moscow");

            //var location = await weather.GetInfoByLattLong(moscow[0].Coordinates);

            //var info = await weather.GetInfoById(moscow[0]);

            var weather_info = await weather.GetWeatherByIdAndTime(moscow[0].Id, DateTime.Now);

            Console.WriteLine("Completed successfully!");
            Console.ReadKey();
            await host.StopAsync();
        }
    }
}
