namespace ShadyCode.DomainDrivenDesign.UnitTests.Entity.TestEntities;

internal sealed class PrimitiveTestEntity(int identifier) : Entity<int>(identifier)
{
    public int TestIdentifier => Identifier;
}