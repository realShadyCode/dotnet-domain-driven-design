using ShadyCode.DomainDrivenDesign.UnitTests.Value.TestValues;
using Xunit;

namespace ShadyCode.DomainDrivenDesign.UnitTests.Value;

public sealed class CalculateHashCodeTests
{
    [Fact]
    public void WHEN_Objects_for_comparison_have_equal_values_THEN_Return_the_same_hash_code()
    {
        // Arrange
        const int intValue = 1337;
        const bool booleanValue = true;
        const string stringValue = "test-value";

        var firstValue = new SimpleTestValue(intValue, booleanValue, stringValue);
        var secondValue = new SimpleTestValue(intValue, booleanValue, stringValue);
        
        // Act
        var firstValueHashCode = firstValue.GetHashCode();
        var secondValueHashCode = secondValue.GetHashCode();
        
        // Assert
        Assert.Equal(firstValueHashCode, secondValueHashCode);
    }
}