//using System.Linq;
//using Machine.Specifications;
//using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

//namespace code.utility.matching
//{
//	[Subject(typeof(FallsInMatchingExtensions))]
//	public class FallsInMatchingExtensionsSpec
//	{
//		public class SomeType
//		{
//		}

//		public abstract class concern : spec.observe<IProvideAccessToMatchBuilders<SomeType, int, Criteria<SomeType>>,
//			MatchingExtensionPoint<SomeType, int>>
//		{
//			Establish c = () =>
//			{
//				instance = new SomeType();

//				depends.on<IGetTheValueOfAProperty<SomeType, int>>(x =>
//				{
//					x.ShouldEqual(instance);
//					return 4;
//				});
//			};
//			protected static SomeType instance;

//			public class when_making_ranges : concern
//		{
//			private static Criteria<int> sut;

//			public class falls_in_range
//			{
//				Establish c = () =>
//					sut = FallsInMatchingExtensions.falls_in(instance, )
//			}
//		}
//	}
//}
