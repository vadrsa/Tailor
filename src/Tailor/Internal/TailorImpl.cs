using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Tailor.Internal
{
    public class TailorImpl : ITailor
    {
        private const string ConfigurationBasePath = "Tailor";
        private readonly IConfiguration _configuration;
        private readonly IEnumerable<IRuleRepository> _repositories;

        public TailorImpl(IEnumerable<IConfigurationSourceProvider> sourceProviders, IEnumerable<IRuleRepository> repositories)
        {
            _configuration = BuildConfiguration(sourceProviders);
            _repositories = repositories;
        }

        public bool Compile(string ruleName)
        {
            var repository = _repositories.FirstOrDefault(r => r.Exists(ruleName));
            if(repository == null)
            {
                throw new InvalidOperationException($"Rule {ruleName} is not defined in any of the registered repositories.");
            }
            var rule = repository.GetRule(ruleName);
            return _configuration.GetValue($"{rule.Name}", rule.Default);
        }

        private IConfiguration BuildConfiguration(IEnumerable<IConfigurationSourceProvider> sourceProviders)
        {
            var builder = new ConfigurationBuilder();
            foreach (var source in sourceProviders.SelectMany(x => x.GetSources()))
            {
                builder.Add(source);
            }
            return builder.Build();
        }
    }
}
