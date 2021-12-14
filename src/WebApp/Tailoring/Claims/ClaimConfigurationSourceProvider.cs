using Tailor;

namespace WebApp.Tailoring.Claims
{
    public class ClaimConfigurationSourceProvider : IConfigurationSourceProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimConfigurationSourceProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IEnumerable<IConfigurationSource> GetSources()
        {
            var user = _httpContextAccessor.HttpContext?.User;
            if (user != null)
            {
                yield return new ClaimConfigurationSource(user.Claims);
            }
        }
    }
}
