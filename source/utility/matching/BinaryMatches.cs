namespace code.utility.matching
{
  public class BinaryMatches
  {
    public static readonly BinaryMatchType and = (a, b) => a && b;
    public static readonly BinaryMatchType or = (a, b) => a || b;
    public static readonly BinaryMatchType xor = (a, b) => a ^ b;
  }
}