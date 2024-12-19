namespace ShadyCode.DomainDrivenDesign.UnitTests.Entity.TestEntities;

internal sealed class ObjectTestEntity(ObjectIdentifier identifier) : Entity<ObjectIdentifier>(identifier)
{
    public ObjectIdentifier TestIdentifier => Identifier;
}

internal sealed class ObjectIdentifier : IEquatable<ObjectIdentifier>
{
    public ObjectIdentifier(int identifier)
    {
        Identifier = identifier;
    }

    public int Identifier { get; }

    public bool Equals(ObjectIdentifier other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Identifier == other.Identifier;
    }

    public override bool Equals(object obj)
    {
        return ReferenceEquals(this, obj) || obj is ObjectIdentifier other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Identifier;
    }
}