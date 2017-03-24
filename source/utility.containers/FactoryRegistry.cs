using System;
using System.Collections.Generic;

namespace code.utility.containers
{
  public class FactoryRegistry : IFindFactoriesForAType
  {
    IDictionary<Type, ICreateOneDependency> factories;

    public FactoryRegistry(IDictionary<Type, ICreateOneDependency> factories)
    {
      this.factories = factories;
    }

    public ICreateOneDependency get_factory_that_can_create(Type item_to_create)
    {
      return factories[item_to_create];
    }
  }
}