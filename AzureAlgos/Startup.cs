using AzureAlgos.Algorithms.Interfaces;
using AzureAlgos.Algorithms.Sorting;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(AzureAlgos.Startup))]

namespace AzureAlgos
{
    public class Startup : FunctionsStartup
    {
        /// <summary>
        /// Configure services via the builder.
        /// </summary>
        /// <param name="builder">builder to configure</param>
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //Register custom dependencies
            builder.Services.AddSingleton<IQuickSort, QuickSort>();
            builder.Services.AddSingleton<IBubbleSort, BubbleSort>();
        }
    }
}