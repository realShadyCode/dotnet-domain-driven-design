using ShadyCode.DomainDrivenDesign.UnitTests.Entity.TestEntities;
using Xunit;

namespace ShadyCode.DomainDrivenDesign.UnitTests.Entity;

public sealed class CreateEntityWithObjectIdentifierTests
{
    [Fact]
    public void WHEN_Identifier_is_set_to_null_value_THEN_Throw_exception()
    {
        // Arrange
        const ObjectIdentifier identifier = null;

        try
        {
            // Act
            var testEntity = new ObjectTestEntity(identifier);

            // Assert - Unexpected
            Assert.Fail("Expected that ArgumentNullException should have been thrown.");
        }
        catch (ArgumentNullException exception)
        {
            // Assert - Expected
            Assert.Equal("identifier", exception.ParamName);
        }
        catch (Exception exception)
        {
            // Assert - Unexpected
            Assert.Fail($"Unexpected exception was thrown: {exception}");
        }
    }
    
    [Fact]
    public void WHEN_Identifier_is_set_to_non_null_value_THEN_Identifier_set_to_provided_value()
    {
        // Arrange
        var expectedIdentifier = new ObjectIdentifier(1337);

        // Act
        var testEntity = new ObjectTestEntity(expectedIdentifier);
        var actualIdentifier = testEntity.TestIdentifier;

        // Assert
        Assert.Equal(expectedIdentifier, actualIdentifier);
    }
}