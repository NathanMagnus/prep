namespace code.web.core
{
  public class FetchDataUsingInput<Input, Report> : IImplementAUserStory
  {
    IFetchDataUsingInput<Input, Report> query_object;
    ISendResponsesToTheClient response;

    public FetchDataUsingInput(IFetchData<Input, Report> query, ISendResponsesToTheClient response):this(query.run, response)
    {
    }

    public FetchDataUsingInput(IFetchDataUsingInput<Input, Report> query_object, ISendResponsesToTheClient response)
    {
      this.response = response;
      this.query_object = query_object;
    }

    public void process(IProvideDetailsAboutAWebRequest request)
    {
      var input = request.map<Input>();
      response.send(query_object(input));
    }
  }
}