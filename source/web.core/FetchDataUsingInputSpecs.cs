using developwithpassion.specifications.assertions.core;
using developwithpassion.specifications.assertions.interactions;
using Machine.Specifications;
using spec = developwithpassion.specifications.use_engine<Machine.Fakes.Adapters.Rhinomocks.RhinoFakeEngine>;

namespace code.web.core
{
  [Subject(typeof(FetchDataUsingInput<,>))]
  public class FetchDataUsingInputSpecs
  {
    public class SomeInput
    {
    }

    public class SomeReport
    {
    }

    public abstract class concern : spec.observe<IImplementAUserStory, FetchDataUsingInput<SomeInput, SomeReport>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IProvideDetailsAboutAWebRequest>();
        response = depends.on<ISendResponsesToTheClient>();
        data = new SomeReport();
        input = new SomeInput();
        query = depends.on<IFetchData<SomeInput, SomeReport>>();
        query.setup(x => x.run(input)).Return(data);

        request.setup(x => x.map<SomeInput>()).Return(input);
      };

      Because b = () =>
        sut.process(request);

      It uses_the_response_engine_to_send_the_data_returned_by_the_query = () =>
        response.should().received(x => x.send(data));

      static IProvideDetailsAboutAWebRequest request;
      static ISendResponsesToTheClient response;
      static SomeReport data;
      static IFetchData<SomeInput, SomeReport> query;
      static SomeInput input;
    }
  }
}