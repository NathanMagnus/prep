using System;
using code.utility.core;

namespace code.utility.iteration
{
  public class Visitor<Element, Result> : IProcessAndReturnAValue<Element, Result>
  {
	  private dynamic sum;
	  private readonly IGetTheValueOfAProperty<Element, Result> accessor;

	  public Visitor(IGetTheValueOfAProperty<Element, Result> accessor)
	  {
		  this.accessor = accessor;
	  }

		public void process(Element value)
		{
			dynamic v = accessor(value);
			sum += v;
		}

	  public Result get_result()
	  {
			return sum;
	  }
  }
}