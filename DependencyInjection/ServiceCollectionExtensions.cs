using FinanceTrackerTemplate.Models.Repositories.Interfaces;
using FinanceTrackerTemplate.Services;
using FinanceTrackerTemplate.Services.Interfaces;
using FinanceTrackerTemplate.Repositories.Interfaces;
using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.UI;
using FinanceTrackerTemplate.Interfaces;



namespace FinanceTrackerTemplate.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFinanceServices(this IServiceCollection services)
        {
            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<IReportService, ReportService>();

            // Repositories
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IDataStorageService, JsonStorageRepository>();

            return services;
        }
    }
}
