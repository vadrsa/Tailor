using Microsoft.Extensions.Configuration.Memory;
using System.Security.Claims;

namespace WebApp.Tailoring.Claims
{
    public class ClaimConfigurationSource : MemoryConfigurationSource
    {
        public ClaimConfigurationSource(IEnumerable<Claim> claims)
        {
            InitialData = claims.ToDictionary(x => x.Type, x => x.Value);
        }
    }
}
