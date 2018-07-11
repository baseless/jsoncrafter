namespace JsonCrafter.Rules
{
    public interface IJsonRuleBuilder
    {
        IJsonRuleSet Build();
        IJsonTypeRule<T> For<T>() where T : class, new();
    }
}
