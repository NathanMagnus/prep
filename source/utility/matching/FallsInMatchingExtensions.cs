﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace code.utility.matching
{
 
  public static class FallsInMatchingExtensions
  {
    public static Criteria<Item> falls_in<Item,Property>(this IProvideAccessToMatchBuilders<Item,Property> extension_point, Criteria<Property> compare) where Property : IComparable<Property>
    {
      return extension_point.create(compare);
    }

  }

  public static class Range
  {
    public static Criteria<Value> after<Value>(Value value, bool inclusive) where Value : IComparable<Value>
    {
      return x => inclusive ? x.CompareTo(value) >= 0 : x.CompareTo(value) > 0;
    }
    
    public static Criteria<Value> before<Value>(Value value, bool inclusive) where Value : IComparable<Value>
    {
      return x => inclusive ? x.CompareTo(value) <= 0 : x.CompareTo(value) < 0;
    }
    
    public static Criteria<Value> between<Value>(Value start, Value end, bool inclusive) where Value : IComparable<Value>
    {
      return x => inclusive ? x.CompareTo(start) >= 0 && x.CompareTo(end) <= 0 : x.CompareTo(start) > 0 && x.CompareTo(end) < 0;
    }
  }
}
