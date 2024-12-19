using System;
using System.Collections.Generic;

namespace ShadyCode.DomainDrivenDesign
{
    public abstract class Entity<TIdentifier> : IEquatable<Entity<TIdentifier>>
    {
        protected Entity(TIdentifier identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException(nameof(identifier));
            }

            Identifier = identifier;
        }

        protected TIdentifier Identifier { get; }
        
        public bool Equals(Entity<TIdentifier> other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return EqualityComparer<TIdentifier>.Default.Equals(Identifier, other.Identifier);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Entity<TIdentifier>)obj);
        }
        
        public static bool operator ==(Entity<TIdentifier> lhs, Entity<TIdentifier> rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                return false;
            }

            return lhs.Equals(rhs);
        }
        
        public static bool operator ==(Entity<TIdentifier> lhs, object rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                return false;
            }

            return lhs.Equals(rhs);
        }
        
        public static bool operator !=(Entity<TIdentifier> lhs, Entity<TIdentifier> rhs) => !(lhs == rhs);
        public static bool operator !=(Entity<TIdentifier> lhs, object rhs) => !(lhs == rhs);

        public override int GetHashCode()
        {
            return EqualityComparer<TIdentifier>.Default.GetHashCode(Identifier);
        }
    }
}