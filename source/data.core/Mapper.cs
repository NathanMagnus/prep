using code.utility.containers;

namespace code.data.core
{
  public class Mapper : IMap
  {
    IFetchDependencies container;

    public Mapper(IFetchDependencies container)
    {
      this.container = container;
    }

    public Output from<Input, Output>(Input input)
    {
      return container.an<IMapFrom<Input, Output>>().map(input);
    }
  }
}