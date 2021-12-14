using System;
using Tailor;
using Tailor.Internal;
using Tailor.AspNetCore;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static ITailorBuilder AddTailor(this IServiceCollection services)
        {
            services.AddScoped<ITailor, TailorImpl>();
            return new TailorBuilder(services);
        }
    }
}
