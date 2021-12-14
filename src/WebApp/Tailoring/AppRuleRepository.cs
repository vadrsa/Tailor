using Tailor;

namespace WebApp.Tailoring
{
    public class AppRuleRepository : StaticRuleRepository
    {
        public static Rule AllowTest { get; } = new Rule(
            name: "AllowTest",
            defaultValue: true
        );
    }
}
