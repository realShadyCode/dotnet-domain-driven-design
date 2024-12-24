using ShadyCode.DomainDrivenDesign.UnitTests.Entity.TestEntities;
using Xunit;

namespace ShadyCode.DomainDrivenDesign.UnitTests.Entity;

public sealed class CompareEntitiesWithObjectNotEqualsOperatorTests
{
    [Fact]
    public void WHILE_Identifier_is_primitive_WHEN_Entity_identities_are_equal_THEN_Entities_are_equal()
    {
        // Arrange
        const int primitiveEntity1Identifier = 1337;
        const int primitiveEntity2Identifier = primitiveEntity1Identifier;

        var primitiveEntity1 = new PrimitiveTestEntity(primitiveEntity1Identifier);
        object primitiveEntity2 = new PrimitiveTestEntity(primitiveEntity2Identifier);
        
        // Act
        var areNotEqual = primitiveEntity1 != primitiveEntity2;
        
        // Assert
        Assert.False(areNotEqual);
    }
    
    [Fact]
    public void WHILE_Identifier_is_primitive_WHEN_Entity_identities_are_not_equal_THEN_Entities_are_not_equal()
    {
        // Arrange
        const int primitiveEntity1Identifier = 1337;
        const int primitiveEntity2Identifier = 42;

        var primitiveEntity1 = new PrimitiveTestEntity(primitiveEntity1Identifier);
        object primitiveEntity2 = new PrimitiveTestEntity(primitiveEntity2Identifier);
        
        // Act
        var areNotEqual = primitiveEntity1 != primitiveEntity2;
        
        // Assert
        Assert.True(areNotEqual);
    }

    [Fact]
    public void WHILE_Identifier_is_object_WHEN_Entity_identifiers_are_same_object_THEN_Entities_are_equal()
    {
        // Arrange
        const int identifier = 1337;
        
        var objectEntityIdentifier1 = new ObjectIdentifier(identifier);
        var objectEntityIdentifier2 = objectEntityIdentifier1;

        var objectEntity1 = new ObjectTestEntity(objectEntityIdentifier1);
        object objectEntity2 = new ObjectTestEntity(objectEntityIdentifier2);
        
        // Act
        var areNotEqual = objectEntity1 != objectEntity2;
        
        // Assert
        Assert.False(areNotEqual);
    }
    
    [Fact]
    public void WHILE_Identifier_is_object_WHEN_Entity_identifiers_are_different_object_with_same_value_THEN_Entities_are_equal()
    {
        // Arrange
        const int identifier = 1337;
        
        var objectEntityIdentifier1 = new ObjectIdentifier(identifier);
        var objectEntityIdentifier2 = new ObjectIdentifier(identifier);

        var objectEntity1 = new ObjectTestEntity(objectEntityIdentifier1);
        object objectEntity2 = new ObjectTestEntity(objectEntityIdentifier2);
        
        // Act
        var areNotEqual = objectEntity1 != objectEntity2;
        
        // Assert
        Assert.False(areNotEqual);
    }
    
    [Fact]
    public void WHILE_Identifier_is_object_WHEN_Entity_identifiers_are_different_object_with_different_values_THEN_Entities_are_not_equal()
    {
        // Arrange
        const int identifier1 = 1337;
        const int identifier2 = 42;
        
        var objectEntityIdentifier1 = new ObjectIdentifier(identifier1);
        var objectEntityIdentifier2 = new ObjectIdentifier(identifier2);

        var objectEntity1 = new ObjectTestEntity(objectEntityIdentifier1);
        object objectEntity2 = new ObjectTestEntity(objectEntityIdentifier2);
        
        // Act
        var areNotEqual = objectEntity1 != objectEntity2;
        
        // Assert
        Assert.True(areNotEqual);
    }

    [Fact]
    public void WHILE_Identifier_is_object_WHEN_Right_hand_side_is_null_THEN_Entities_are_not_equal()
    {
        // Arrange
        const int identifier = 1337;
        
        var objectEntityIdentifier = new ObjectIdentifier(identifier);

        var objectEntity1 = new ObjectTestEntity(objectEntityIdentifier);
        object objectEntity2 = null;
        
        // Act
        var areNotEqual = objectEntity1 != objectEntity2;
        
        // Assert
        Assert.True(areNotEqual);
    }
    
    [Fact]
    public void WHILE_Identifier_is_object_WHEN_Left_hand_side_is_null_THEN_Entities_are_not_equal()
    {
        // Arrange
        const int identifier = 1337;
        
        var objectEntityIdentifier = new ObjectIdentifier(identifier);

        ObjectTestEntity objectEntity1 = null;
        object objectEntity2 = new ObjectTestEntity(objectEntityIdentifier);
        
        // Act
        var areNotEqual = objectEntity1 != objectEntity2;
        
        // Assert
        Assert.True(areNotEqual);
    }
    
    [Fact]
    public void WHILE_Identifier_is_object_WHEN_Both_sides_are_null_THEN_Entities_are_equal()
    {
        // Arrange
        ObjectTestEntity objectEntity1 = null;
        object objectEntity2 = null;
        
        // Act
        var areNotEqual = objectEntity1 != objectEntity2;
        
        // Assert
        Assert.False(areNotEqual);
    }
}