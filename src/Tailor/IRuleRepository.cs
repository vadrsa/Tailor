namespace Tailor
{
    /// <summary>
    /// Repository of Rules
    /// </summary>
    public interface IRuleRepository
    {
        /// <summary>
        /// Checks if a rule exists in the repository
        /// </summary>
        /// <param name="name">Name of the rule to check</param>
        /// <returns>True if the rule exists in the repository, false otherwise</returns>
        bool Exists(string name);

        /// <summary>
        /// Get a rule by name
        /// </summary>
        /// <param name="name">Name of the rule to get</param>
        Rule GetRule(string name);
    }
}
