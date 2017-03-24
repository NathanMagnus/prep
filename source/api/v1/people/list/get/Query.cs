using System.Collections.Generic;
using code.prep.people;
using code.test_utilities;
using code.web.core;

namespace code.api.v1.people.list.get
{
  public class Query : IFetchData<Input, IEnumerable<Person>>
  {
    public IEnumerable<Person> run(Input input)
    {
      return Factories.generate(100, x => Factories.create_person());
    }
  }
}