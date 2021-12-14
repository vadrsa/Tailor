namespace Tailor
{
    public struct Rule
    {
        public Rule(string name, bool defaultValue)
        {
            Name = name;
            Default = defaultValue;
        }

        public string Name { get; }
        public bool Default { get; }
    }
}
