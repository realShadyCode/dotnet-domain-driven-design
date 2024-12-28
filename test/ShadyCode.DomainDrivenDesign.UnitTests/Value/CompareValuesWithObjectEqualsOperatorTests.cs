using ShadyCode.DomainDrivenDesign.UnitTests.Value.TestValues;
using Xunit;

namespace ShadyCode.DomainDrivenDesign.UnitTests.Value;

public sealed class CompareValuesWithObjectEqualsOperatorTests
{
    [Fact]
    public void WHILE_Values_have_simple_data_WHEN_Values_contain_same_data_THEN_Values_are_equal()
    {
        // Arrange
        const int intValue = 1337;
        const bool booleanValue = true;
        const string stringValue = "test-value";

        var value1 = new SimpleTestValue(intValue, booleanValue, stringValue);
        object value2 = new SimpleTestValue(intValue, booleanValue, stringValue);
        
        // Act
        var areEqual = value1 == value2;
        
        // Assert
        Assert.True(areEqual);
    }
    
    [Fact]
    public void WHILE_Values_have_simple_data_WHEN_Values_contains_different_data_THEN_Values_are_not_equal()
    {
        // Arrange
        const int intValue = 1337;
        const bool booleanValue = true;
        const string stringValue1 = "test-value-1";
        const string stringValue2 = "test-value-2";

        var value1 = new SimpleTestValue(intValue, booleanValue, stringValue1);
        object value2 = new SimpleTestValue(intValue, booleanValue, stringValue2);
        
        // Act
        var areEqual = value1 == value2;
        
        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void WHEN_Values_have_nested_value_object_WHEN_Values_objects_are_same_object_THEN_Values_are_equal()
    {
        // Arrange
        const int intValue = 1337;
        const bool booleanValue = true;
        const string stringValue = "test-value";
        
        var simpleTestValue = new SimpleTestValue(intValue, booleanValue, stringValue);
        
        var value1 = new NestedObjectTestValue(simpleTestValue);
        object value2 = new NestedObjectTestValue(simpleTestValue);
        
        // Act
        var areEqual = value1 == value2;
        
        // Assert
        Assert.True(areEqual);
    }
    
    [Fact]
    public void WHEN_Values_have_nested_value_object_WHEN_Values_objects_are_different_objects_with_same_values_THEN_Values_are_equal()
    {
        // Arrange
        const int intValue = 1337;
        const bool booleanValue = true;
        const string stringValue = "test-value";
        
        var simpleTestValue1 = new SimpleTestValue(intValue, booleanValue, stringValue);
        var simpleTestValue2 = new SimpleTestValue(intValue, booleanValue, stringValue);
        
        var value1 = new NestedObjectTestValue(simpleTestValue1);
        object value2 = new NestedObjectTestValue(simpleTestValue2);
        
        // Act
        var areEqual = value1 == value2;
        
        // Assert
        Assert.True(areEqual);
    }
    
    [Fact]
    public void WHEN_Values_have_nested_value_object_WHEN_Values_objects_are_different_objects_with_different_values_THEN_Values_are_not_equal()
    {
        // Arrange
        const int intValue = 1337;
        const bool booleanValue = true;
        const string stringValue1 = "test-value-1";
        const string stringValue2 = "test-value-2";
        
        var simpleTestValue1 = new SimpleTestValue(intValue, booleanValue, stringValue1);
        var simpleTestValue2 = new SimpleTestValue(intValue, booleanValue, stringValue2);
        
        var value1 = new NestedObjectTestValue(simpleTestValue1);
        object value2 = new NestedObjectTestValue(simpleTestValue2);
        
        // Act
        var areEqual = value1 == value2;
        
        // Assert
        Assert.False(areEqual);
    }

    [Fact]
    public void WHEN_Input_is_null_THEN_Values_are_not_equal()
    {
        // Arrange
        const int intValue = 1337;
        const bool booleanValue = true;
        const string stringValue = "test-value";
        
        var simpleTestValue = new SimpleTestValue(intValue, booleanValue, stringValue);
        
        var value1 = new NestedObjectTestValue(simpleTestValue);
        object value2 = null;
        
        // Act
        var areEqual = value1 == value2;
        
        // Assert
        Assert.False(areEqual);
    }
}