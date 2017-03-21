using System;

namespace code.utility.matching
{
	public class RangeExtensionPoint<Item> : IProvideAccessToMatchBuilders<Item, Item>
		where Item : IComparable<Item>
	{
		IGetTheValueOfAProperty<Item, Item> accessor { get; }
		public readonly Item start;

		public RangeExtensionPoint(IGetTheValueOfAProperty<Item, Item> accessor, Item start)
		{
			this.accessor = accessor;
			this.start = start;
		}

		public Criteria<Item> create(Criteria<Item> value_matcher)
		{
			return x => value_matcher(accessor(x));
		}

		public IProvideAccessToMatchBuilders<Item, Item> Inclusive
		{
			get { return new InclusiveExtensionPoint(this, start, accessor); }
		}

		class InclusiveExtensionPoint : IProvideAccessToMatchBuilders<Item, Item>
		{
			private Item start;
			private IProvideAccessToMatchBuilders<Item, Item> original;
			private IGetTheValueOfAProperty<Item, Item> accessor;

			public InclusiveExtensionPoint(IProvideAccessToMatchBuilders<Item, Item> original, Item start, IGetTheValueOfAProperty<Item, Item> accessor)
			{
				this.original = original;
				this.start = start;
				this.accessor = accessor;
			}

			public Criteria<Item> create(Criteria<Item> value_matcher)
			{
				return original.create(x => value_matcher(x) || accessor(x).CompareTo(start) == 0);
			}
		}
	}

	public class Range
	{
		public static RangeExtensionPoint<Item> starting_at<Item>(Item starting_point) where Item : IComparable<Item>
		{
			return new RangeExtensionPoint<Item>(x => x, starting_point);
		}
	}

  public static class FallsInMatchingExtensions
  {
    public static Criteria<Item> falls_in<Item,Property>(this IProvideAccessToMatchBuilders<Item,Property> extension_point, Criteria<Property> criteria) where Property : IComparable<Property>
    {
	    return extension_point.create(criteria);
    }

	  public static IProvideAccessToMatchBuilders<Item, Item> inclusive<Item>(this RangeExtensionPoint<Item> range)
		  where Item : IComparable<Item>
	  {
		  return range.Inclusive;
	  }

	  public static RangeExtensionPoint<Item> upto<Item>(this RangeExtensionPoint<Item> range, Item ending_point)
			where Item : IComparable<Item>
	  {
		  return x => x.CompareTo(ending_point) < 0;
	  }
  }


}