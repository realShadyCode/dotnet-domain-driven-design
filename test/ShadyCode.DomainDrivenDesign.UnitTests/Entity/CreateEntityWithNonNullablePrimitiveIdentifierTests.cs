using ShadyCode.DomainDrivenDesign.UnitTests.Entity.TestEntities;
using Xunit;

namespace ShadyCode.DomainDrivenDesign.UnitTests.Entity;

public sealed class CreateEntityWithNonNullablePrimitiveIdentifierTests
{
    [Fact]
    public void THEN_Identifier_set_to_provided_value()
    {
        // Arrange
        const int expectedIdentifier = 1337;

        // Act
        var testEntity = new PrimitiveTestEntity(expectedIdentifier);
        var actualIdentifier = testEntity.TestIdentifier;

        // Assert
        Assert.Equal(expectedIdentifier, actualIdentifier);
    }
}