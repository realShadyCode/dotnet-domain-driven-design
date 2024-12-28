using ShadyCode.DomainDrivenDesign.UnitTests.Entity.TestEntities;
using Xunit;

namespace ShadyCode.DomainDrivenDesign.UnitTests.Entity;

public sealed class CalculateHashCodeTests
{
    [Fact]
    public void WHILE_Identifier_is_primitive_WHEN_Getting_hash_code_THEN_Return_identifier_hash_code()
    {
        // Arrange
        const int primitiveEntityIdentifier = 1337;
        var primitiveEntity = new PrimitiveTestEntity(primitiveEntityIdentifier);
        
        var expectedHashCode = primitiveEntityIdentifier.GetHashCode();
        
        // Act
        var actualHashCode = primitiveEntity.GetHashCode();
        
        // Assert
        Assert.Equal(expectedHashCode, actualHashCode);
    }
    
    [Fact]
    public void WHILE_Identifier_is_object_WHEN_Getting_hash_code_THEN_Return_identifier_hash_code()
    {
        // Arrange
        const int identifier = 1337;
        var objectEntityIdentifier = new ObjectIdentifier(identifier);
        var objectEntity = new ObjectTestEntity(objectEntityIdentifier);
        
        var expectedHashCode = objectEntityIdentifier.GetHashCode();
        
        // Act
        var actualHashCode = objectEntity.GetHashCode();
        
        // Assert
        Assert.Equal(expectedHashCode, actualHashCode);
    }
}