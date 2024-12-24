# Domain Driven Design Components
![ci branch parameter](https://github.com/realShadyCode/dotnet-domain-driven-design/actions/workflows/continuous-integration.yml/badge.svg?branch=main)

A tiny .NET library that provides base classes for projects that wants to use Domain Driven Design principles and/or want to use the tiny type pattern.

The code is heavily inspired by the book Patterns, Principles, and Practices of Domain-Driven Design by Scott Millett.

## Entity

The class [Entity](src/ShadyCode.DomainDrivenDesign/Entity.cs) provides a base class for classes that represent entities and aggregate roots.

An entity is defined by having a unique identifier. If two entities have identifiers with the same value, they represent the same entity. This is true even if the remaining data it the two entities are different.

```csharp
public sealed class Basket : Entity<Guid>
{
  public Basket(Guid identifier, Address invoiceAddress, Address? deliveryAddress) : base(identifier)
  {
     InvoiceAddress = invoiceAddress;
     DeliveryAddress = deliveryAddress;
  }
  
  public Address InvoiceAddress { get; }
  public Address? DeliveryAddress { get; }
}
```
Any type can technically be used as the identifier of an entity. Keep in mind though, that custom identifier classes should implement the `IEquatable<T>` interface.

### The Identifier
The `Identifier` property is protected by default. If access to it from the outside is desired, the child class can opt to expose it:

```csharp
public sealed class Basket : Entity<Guid>
{
  public Basket(Guid identifier) : base(identifier)
  {
  }
  
  public Guid BasketIdentifier => Identifier;
}
```

### Comparing
The `Equals()` methods are implemented to only compare the Identifiers. So are the `==` and `!=` operators.

```csharp
var basket1 = new Basket(Guid.Parse("b7f8551e-5379-4c59-92dd-2f9ad845fd3c"));
var basket2 = new Basket(Guid.Parse("b7f8551e-5379-4c59-92dd-2f9ad845fd3c"));

var isTheBaseBasketEquals = basket1.Equals(basket2); // isTheBaseBasketEquals = true
var isTheBaseBasketOperator = basket1 == basket2; // isTheBaseBasketOperator = true
```

## Value
Coming soon...

### Auto Value
Coming soon... but a little later.

### Tiny Types
Coming at some point...

*Copyright © 2024 ShadyCode, Michel Gammelgaard. All rights reserved. Provided under the [Apache License, Version 2.0](http://apache.org/licenses/LICENSE-2.0.html).*