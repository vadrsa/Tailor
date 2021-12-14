using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Tailor
{
    /// <summary>
    /// Abstract implmentation of <see cref="IRuleRepository"/> that uses static properties definied on the child class
    /// </summary>
    public abstract class StaticRuleRepository : IRuleRepository
    {
        private readonly Dictionary<string, Rule> _internalMap = new Dictionary<string, Rule>();

        public StaticRuleRepository()
        {
            _internalMap = InitializeMap();
        }

        public bool Exists(string name)
            => _internalMap.ContainsKey(name);

        public Rule GetRule(string name)
            => _internalMap[name];

        private Dictionary<string, Rule> InitializeMap()
        => GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(pi => pi.PropertyType.Equals(typeof(Rule)) || typeof(IEnumerable<Rule>).IsAssignableFrom(pi.PropertyType))
            .SelectMany(GetRuleFromPropertyInfo)
            .ToDictionary(x => x.Name, x => x);

        private IEnumerable<Rule> GetRuleFromPropertyInfo(PropertyInfo pi)
        {
            var value = pi.GetValue(null);
            if (value is Rule)
            {
                yield return (Rule)value;
            }
            else
            {
                foreach (var rule in (IEnumerable<Rule>)value)
                {
                    yield return rule;
                }
            }
        }

    }
}
