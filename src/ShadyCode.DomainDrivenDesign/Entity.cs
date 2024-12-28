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
    /// <summary>
    /// The base type for classes that represent entities.
    /// </summary>
    /// <remarks>
    /// An entity is identified solely by its identity. If two entities of the same type has the same identifier value,
    /// they are considered equal. This is true even if they otherwise contain different data.
    /// </remarks>
    /// <typeparam name="TIdentifier">The type used to uniquely identify the entity.</typeparam>
    public abstract class Entity<TIdentifier> : IEquatable<Entity<TIdentifier>>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Entity{TIdentifier}"/>.
        /// </summary>
        /// <param name="identifier">The entity identifier.</param>
        /// <exception cref="ArgumentNullException"><paramref name="identifier" /> is <see langword="null" />.</exception>
        protected Entity(TIdentifier identifier)
        {
            if (identifier == null)
            {
                throw new ArgumentNullException(nameof(identifier));
            }

            Identifier = identifier;
        }

        /// <summary>
        /// The identifier.
        /// </summary>
        protected TIdentifier Identifier { get; }
        
        /// <summary>Determines whether two object instances are equal.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Entity<TIdentifier> obj)
        {
            if (obj is null)
            {
                return false;
            }
            
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            
            return EqualityComparer<TIdentifier>.Default.Equals(Identifier, obj.Identifier);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }
            
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }
            
            return Equals((Entity<TIdentifier>) obj);
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
        
        public static bool operator !=(Entity<TIdentifier> lhs, Entity<TIdentifier> rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return false;

                return true;
            }

            return !lhs.Equals(rhs);
        }
        
        public static bool operator !=(Entity<TIdentifier> lhs, object rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return false;

                return true;
            }

            return !lhs.Equals(rhs);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return EqualityComparer<TIdentifier>.Default.GetHashCode(Identifier);
        }
    }
}