namespace MyLib.Data
{
    using Dapper;
    using Microsoft.Data.Sqlite;

    public class DataService : IDataService
    {        
        public string GetData()
        {
            using(var conn = new SqliteConnection("Data Source=:memory:"))
            {
                conn.Open();
                var res = conn.ExecuteScalar("SELECT 1;").ToString();
                return res;
            }
        }
    }
}
