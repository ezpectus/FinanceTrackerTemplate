using FinanceTrackerTemplate.DependencyInjection;
using FinanceTrackerTemplate.UI;

namespace FinanceTrackerTemplate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var services = new SimpleServiceCollection();
            services.AddFinanceServices();
            services.AddTransient<ConsoleUI>();

            var provider = services.BuildServiceProvider();
            var ui = ((SimpleServiceProvider)provider).GetRequiredService<ConsoleUI>();
            ui.Run();
        }
    }
}


