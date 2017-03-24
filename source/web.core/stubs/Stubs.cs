using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using code.api.v1.people.list.get;
using code.prep.people;
using code.test_utilities;
using code.web.adapters;
using Newtonsoft.Json;

namespace code.web.core.stubs
{
  public class Stubs
  {
    public static ICreateARequestFromAnASPNetRequest aspnet_request_builder = x => new StubRequest();

    public static ICreateAMissingCommandWhenOneCantBeFound missing_request_builder = delegate
    {
      throw new NotImplementedException("You dont have a handler for this feature");
    };

    public static IEnumerable<IHandleOneWebRequest> dummy_set_of_handlers()
    {
      yield return create_query_handler<Query, Input, IEnumerable<Person>>();
      yield return create_query_handler<api.v1.people._id.get.Query, api.v1.people._id.get.Input, Person>();
    }

    public static IHandleOneWebRequest create_query_handler<QueryObject, Input, Report>() where QueryObject : IFetchData<Input, Report>, new()
    {
      return new RequestHandler(x => true, new FetchDataUsingInput<Input, Report>(new QueryObject(), dummy_response_engine())); 
    } 

    public static IFetchDataUsingTheRequest<IEnumerable<Person>> dummy_list_of_people = x => Factories.generate(200, 
      y => Factories.create_person());
      

    public static ISendResponsesToTheClient dummy_response_engine()
    {
      return new StubResponseEngine();
    }
  }

  public class StubResponseEngine : ISendResponsesToTheClient
  {
    public void send<Data>(Data data)
    {
      var context = HttpContext.Current;
      context.Response.ContentType = "application/json";
      var serialize = new JsonSerializer();

      using (var writer = new JsonTextWriter(new StreamWriter(context.Response.OutputStream)))
      {
        serialize.Serialize(writer, data);
      }
    }
  }

  public class StubRequest : IProvideDetailsAboutAWebRequest
  {
    public InputModel map<InputModel>()
    {
      return Activator.CreateInstance<InputModel>();
    }
  }
}