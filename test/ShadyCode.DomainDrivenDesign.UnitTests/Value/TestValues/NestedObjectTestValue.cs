namespace ShadyCode.DomainDrivenDesign.UnitTests.Value.TestValues;

internal sealed class NestedObjectTestValue : Value<NestedObjectTestValue>
{
    public NestedObjectTestValue(SimpleTestValue simpleTestValue)
    {
        SimpleTestValue = simpleTestValue;
    }
    
    public SimpleTestValue SimpleTestValue { get; }
    
    protected override List<object> GetObjectsForEqualityCheck()
    {
        return [SimpleTestValue];
    }
}