using System.Collections.Generic;
using System.Data;

namespace code.data.core
{
  public class QueryForASet<Element> : IRunAQuery<IEnumerable<Element>>
  {
    IMap mapper;
    string query;

    public QueryForASet(IMap mapper, string query)
    {
      this.mapper = mapper;
      this.query = query;
    }

    public QueryForASet(IMap mapper)
    {
      this.mapper = mapper;
    }

    public void prepare(IDbCommand command)
    {
      command.CommandType = CommandType.Text;
      command.CommandText = query;
    }

    public IEnumerable<Element> map(IDataReader reader)
    {
      var table = new DataTable();
      table.Load(reader);

      foreach (DataRow row in table.Rows)
        yield return mapper.@from<DataRow, Element>(row);
    }
  }
}