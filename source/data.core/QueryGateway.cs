namespace code.data.core
{
  public class QueryGateway
  {
    ICreateDbConnections db_connection_factory;

    public QueryGateway(ICreateDbConnections db_connection_factory)
    {
      this.db_connection_factory = db_connection_factory;
    }

    public QueryResult run<QueryResult>(IRunAQuery<QueryResult> query)
    {
      var connection = db_connection_factory.create();
      var command = connection.CreateCommand();
      query.prepare(command);
      connection.Open();

      return query.map(command.ExecuteReader());
    }
  }
}