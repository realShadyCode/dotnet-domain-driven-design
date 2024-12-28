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
using System.Linq;

namespace ShadyCode.DomainDrivenDesign
{
    /// <summary>
    /// The base type for classes that represent values.
    /// </summary>
    /// <remarks>
    /// An entity is identified solely by its value(s). If two values of the same type has the same value(s), they are
    /// considered equal.
    /// The list of objects to consider in equality checks are provided by overriding the abstract method
    /// <see cref="GetObjectsForEqualityCheck"/> and returning the list here.
    /// </remarks>
    /// <typeparam name="TValue">The type of the value class.</typeparam>
    public abstract class Value<TValue>: IEquatable<TValue> where TValue : Value<TValue>
    {
        /// <summary>
        /// Creates a new instance of <see cref="Value{TValue}"/>.
        /// </summary>
        protected Value()
        {
            _lazyObjectsForEqualityCheck = new Lazy<IReadOnlyCollection<object>>(() => GetObjectsForEqualityCheck().AsReadOnly());
        }

        private readonly Lazy<IReadOnlyCollection<object>> _lazyObjectsForEqualityCheck;
        
        /// <summary>
        /// Gets a list with references to the objects that are going to be used in equality checks.
        /// </summary>
        /// <returns>The list of objects to be used in equality checks.</returns>
        protected abstract List<object> GetObjectsForEqualityCheck();

        /// <inheritdoc />
        public sealed override bool Equals(object obj)
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
            
            return Equals((TValue) obj);
        }

        /// <summary>Determines whether two object instances are equal.</summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified object  is equal to the current object; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(TValue obj)
        {
            if (obj is null)
            {
                return false;
            }
            
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return _lazyObjectsForEqualityCheck.Value.SequenceEqual(obj._lazyObjectsForEqualityCheck.Value);
        }
        
        public static bool operator ==(Value<TValue> lhs, Value<TValue> rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                return false;
            }

            return lhs.Equals(rhs);
        }
        
        public static bool operator ==(Value<TValue> lhs, object rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return true;

                return false;
            }

            return lhs.Equals(rhs);
        }
        
        public static bool operator !=(Value<TValue> lhs, Value<TValue> rhs)
        {
            if (lhs is null)
            {
                if (rhs is null)
                    return false;

                return true;
            }

            return !lhs.Equals(rhs);
        }
        
        public static bool operator !=(Value<TValue> lhs, object rhs)
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
            return _lazyObjectsForEqualityCheck.Value.Aggregate(
                17,
                (current, objectForEqualityCheck) => current * 23 + objectForEqualityCheck.GetHashCode()
            );
        }
    }
}