namespace ShadyCode.DomainDrivenDesign.UnitTests.Entity.TestEntities;

internal sealed class NullablePrimitiveTestEntity : Entity<int?>
{
    public NullablePrimitiveTestEntity(int? identifier) : base(identifier)
    {
    }
    
    public int? TestIdentifier => Identifier;
}