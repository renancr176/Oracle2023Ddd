﻿using Bogus;
using Xunit;

namespace Rte2023Ddd.Test.Fixtures;

[CollectionDefinition(nameof(EntityColletion))]
public class EntityColletion : ICollectionFixture<EntityFixture>
{ }

public class EntityFixture : IDisposable
{
    public Faker Faker { get; private set; }


    public EntityFixture()
    {
        Faker = new Faker("pt_BR");
    }

    public void Dispose()
    {
    }
}