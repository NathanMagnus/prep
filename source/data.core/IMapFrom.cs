namespace code.data.core
{
  public interface IMapFrom<Input, Output>
  {
    Output map(Input input); 
  }
}