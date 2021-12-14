using Microsoft.Extensions.DependencyInjection;

namespace Tailor.AspNetCore
{
    internal class TailorBuilder : ITailorBuilder
    {
        public TailorBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IServiceCollection Services { get; }
    }
}
