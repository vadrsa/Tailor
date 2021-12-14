using System;
using System.Linq;
using System.Reflection;
using Tailor;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class TailorBuilderExtensions
    {
        public static ITailorBuilder WithRules<T>(this ITailorBuilder builder)
            where T : class, IRuleRepository
        {
            builder.Services.AddSingleton<IRuleRepository, T>();
            return builder;
        }

        public static ITailorBuilder WithRules(this ITailorBuilder builder, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IRuleRepository)));
            foreach(var type in types)
            {
                builder.Services.AddSingleton(typeof(IRuleRepository), type);
            }
            return builder;
        }

        public static ITailorBuilder WithProvider<T>(this ITailorBuilder builder)
            where T : class, IConfigurationSourceProvider
        {
            builder.Services.AddSingleton<IConfigurationSourceProvider, T>();
            return builder;
        }

        public static ITailorBuilder WithProviders(this ITailorBuilder builder, Assembly assembly)
        {
            var types = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(IConfigurationSourceProvider)));
            foreach (var type in types)
            {
                builder.Services.AddSingleton(typeof(IConfigurationSourceProvider), type);
            }
            return builder;
        }
    }
}
