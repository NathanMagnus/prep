using code.prep.people;
using code.test_utilities;
using code.web.core;

namespace code.api.v1.people._id.get
{
  public class Query : IFetchData<Input, Person>
  {
    public Person run(Input input)
    {
      return Factories.create_person();
    }
  }
}