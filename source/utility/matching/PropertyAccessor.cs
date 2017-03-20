namespace code.utility.matching
{
  public delegate PropertyType PropertyAccessor<in Target, out PropertyType>(Target target);
}