// Copyright 2024 ShadyCode, Michel Gammelgaard
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and limitations under the License.

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