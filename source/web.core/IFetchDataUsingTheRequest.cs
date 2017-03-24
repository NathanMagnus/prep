namespace code.web.core
{
  public delegate Data IFetchDataUsingTheRequest<out Data>(IProvideDetailsAboutAWebRequest request);

  public delegate Data IFetchDataUsingInput<in Input, out Data>(Input input);

  public interface IFetchData<in Input, out Data>
  {
    Data run(Input input);
  }

}