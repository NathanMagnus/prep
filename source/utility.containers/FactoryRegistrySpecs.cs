using System;
using System.Collections.Generic;
using code.utility.containers;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace Namespace
{
  [Subject(typeof(FactoryRegistry))]
  public class FactoryRegistrySpecs
  {
    public class concern : spec.observe<IFindFactoriesForAType, FactoryRegistry>
    {
    }

    public class when_getting_factory_for_a_type : concern
    {
      class SomeType
      {
      }

      Establish context = () =>
      {
        the_appropriate_factory = fake.an<ICreateOneDependency>();
        factories = depends.on<IDictionary<Type, ICreateOneDependency>>(new Dictionary<Type, ICreateOneDependency>());

        factories.Add(typeof(SomeType), the_appropriate_factory);
      };

      Because of = () =>
        result = sut.get_factory_that_can_create(typeof(SomeType));

      It should_return_the_appropriate_factory = () =>
        result.ShouldEqual(the_appropriate_factory);

      static IDictionary<Type, ICreateOneDependency> factories;
      static ICreateOneDependency the_appropriate_factory;
      static ICreateOneDependency result;
    }
  }
}