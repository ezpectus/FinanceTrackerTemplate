using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace FinanceTrackerTemplate.DependencyInjection
    {
        public interface IServiceCollection
        {
            void AddScoped<TInterface, TImplementation>() where TImplementation : TInterface;
            void AddSingleton<TInterface, TImplementation>() where TImplementation : TInterface;
            TInterface GetService<TInterface>();
        }
    }


