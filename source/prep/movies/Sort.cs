using System;
using code.utility;
using code.utility.matching;

namespace code.prep.movies
{
	public delegate int SortOrderType(int a);

	public class SortOrder
	{
		public static SortOrderType descending = i => -i;
		public static SortOrderType ascending = i => i;
	}


	public class Sort<Item>
	{
		public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor, SortOrderType sortOrder) where Property : IComparable<Property>
		{
			return (a, b) => sortOrder(accessor(a).CompareTo(accessor(b)));
		}

		public static ICompareTwoItems<Item> by<Property>(IGetTheValueOfAProperty<Item, Property> accessor, params Property[] sort_order)
		{
			return (a, b) => Array.IndexOf(sort_order, accessor(a)) - Array.IndexOf(sort_order, accessor(b));
		}
	}

	public static class SortExtensions
	{
		public static ICompareTwoItems<Item> then_by<Item, Property>(this ICompareTwoItems<Item> previous_comparer, IGetTheValueOfAProperty<Item, Property> accessor, SortOrderType sortOrder) where Property : IComparable<Property>
		{
			return (a, b) =>
			{
				var previous_result = previous_comparer(a, b);
				return previous_result == 0 ? Sort<Item>.by(accessor, sortOrder)(a, b) : sortOrder(previous_result);
			};
		}

	}
}