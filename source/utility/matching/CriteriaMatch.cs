namespace code.utility.matching
{
  public class CriteriaMatch<Element> : IMatchA<Element>
  {
    Criteria<Element> condition;

    public CriteriaMatch(Criteria<Element> condition)
    {
      this.condition = condition;
    }

    public bool matches(Element item)
    {
      return condition(item);
    }
  }
}