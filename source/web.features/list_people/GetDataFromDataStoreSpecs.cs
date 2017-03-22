using System.Collections.Generic;
using System.Linq;
using code.prep.people;
using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web.features.list_people
{
	[Subject(typeof(GetDataFromSQL<IEnumerable<Person>>))]
	public class GetDataFromDataStoreSpecs
	{

		public abstract class concern : spec.observe<IGetDataFromDataStore<IEnumerable<Person>>, GetDataFromSQL<IEnumerable<Person>>>
		{

		}

		public class when_run : concern
		{
			private Establish c = () =>
			{
				query = fake.an<IFetchDataUsingTheRequest<IEnumerable<Person>>>();
				dataStore = depends.on<IDataStore<IEnumerable<Person>>>();
			};

			private Because b = () =>
				result = sut.GetDataFromDataStore(query);

			private It should_call_run = () =>
				dataStore.should().received(x => x.run(query));

			private It gets_the_list_of_people_from_the_data_store = () =>
				result.ShouldNotBeEmpty();

			private static IFetchDataUsingTheRequest<IEnumerable<Person>> query;
			private static IEnumerable<Person> result;
			private static IDataStore<IEnumerable<Person>> dataStore;
		}
	}
}