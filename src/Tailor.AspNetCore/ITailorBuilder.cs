namespace Microsoft.Extensions.DependencyInjection
{
    public interface ITailorBuilder
    {
        IServiceCollection Services { get; }
    }
}
