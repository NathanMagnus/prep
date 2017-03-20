namespace code.utility.matching
{
  public class BinaryMatch<Item> : IMatchA<Item>
  {
    IMatchA<Item> left;
    IMatchA<Item> right;

    public BinaryMatchType binary_match_type;

    public BinaryMatch(IMatchA<Item> left, IMatchA<Item> right, BinaryMatchType binary_match_type)
    {
      this.left = left;
      this.right = right;
      this.binary_match_type = binary_match_type;
    }

    public bool matches(Item item)
    {
      return binary_match_type(left.matches(item), right.matches(item));
    }
  }
}