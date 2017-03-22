using System;
using System.Collections.Generic;
using System.Linq;
using code.prep.people;
using code.web.stubs;

namespace code.web.features.list_people
{
	public interface IGetDataFromDataStore<Result>
	{
		Result GetDataFromDataStore(IFetchDataUsingTheRequest<Result> query);
	}

	public interface IDataStore<Result>
	{
		Result run(IFetchDataUsingTheRequest<Result> fetcher);
	}

	public class SQLDataStore<Result> : IDataStore<Result>
	{
		public Result run(IFetchDataUsingTheRequest<Result> fetcher)
		{
			// connect to db and get stuff of course
			// faked right now
			throw new NotImplementedException();
		}
	}

	public static class IDataStoreExtensions
	{
		public static Result GetResult<Result>(this IDataStore<Result> store, IFetchDataUsingTheRequest<Result> r)
		{
			return store.run(r);
		}
	}

	public class GetDataFromSQL<Result> : IGetDataFromDataStore<Result>
	{
		private readonly IDataStore<Result> _dataStore;

		public GetDataFromSQL(IDataStore<Result> dataStore)
		{
			_dataStore = dataStore;
		}

		public Result GetDataFromDataStore(IFetchDataUsingTheRequest<Result> query)
		{
			return _dataStore.run(query);
		}
	}

  public class Handler : IImplementAUserStory
  {
	  IFetchDataUsingTheRequest<IEnumerable<Person>> all_people_query;
    ISendResponsesToTheClient response;

    public Handler():this(Stubs.dummy_list_of_people, Stubs.dummy_response_engine())
    {
    }

    public Handler(IFetchDataUsingTheRequest<IEnumerable<Person>> all_people_query, ISendResponsesToTheClient response)
    {
			this.all_people_query = all_people_query;
      this.response = response;
    }

    public void process(IProvideDetailsAboutAWebRequest request)
	  {
      response.send(all_people_query(request));
	  }
  }
}