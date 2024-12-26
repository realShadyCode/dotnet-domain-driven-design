namespace ShadyCode.DomainDrivenDesign.UnitTests.Value.TestValues;

internal sealed class SimpleTestValue : Value<SimpleTestValue>
{
    public SimpleTestValue(int intProperty, bool booleanProperty, string stringProperty)
    {
        IntProperty = intProperty;
        BooleanProperty = booleanProperty;
        StringProperty = stringProperty;
    }

    public int IntProperty { get; }
    public bool BooleanProperty { get; }
    public string StringProperty { get; }
    
    protected override List<object> GetObjectsForEqualityCheck()
    {
        return [IntProperty, BooleanProperty, StringProperty];
    }
}