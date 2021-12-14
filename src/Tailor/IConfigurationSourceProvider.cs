using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Tailor
{
    public interface IConfigurationSourceProvider
    {
        IEnumerable<IConfigurationSource> GetSources();
    }
}
