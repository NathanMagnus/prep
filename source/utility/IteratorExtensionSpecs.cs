using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.utility
{
  [Subject(typeof(IteratorExtensions))]
  public class IteratorExtensionSpecs
  {
    public class when_applying_a_filter_to_a_set_of_items : spec.observe
    {
      Because b = () =>
        results = Enumerable.Range(1, 10).filter_using(x => x%2 == 0);

      It returns_only_the_items_that_match_the_filter = () =>
        results.Count().ShouldEqual(5);

      static IEnumerable<int> results;
    }
  }
}