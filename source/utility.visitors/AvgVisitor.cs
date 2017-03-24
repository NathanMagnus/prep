namespace code.utility.visitors
{
  public class AvgVisitor<Element, Result> : IProcessAndReturnAValue<Element, Result>
  {
    IProcessAndReturnAValue<Element, Result> reducer;
    int count;

    public AvgVisitor(IProcessAndReturnAValue<Element, Result> reducer)
    {
      this.reducer = reducer;
    }

    public void process(Element value)
    {
      reducer.process(value);
      count++;
    }

    public Result get_result()
    {
      return (dynamic) reducer.get_result()/count;
    }
  }
}