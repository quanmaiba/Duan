using System;
using System.Data;
using System.Data.SqlClient;

namespace University.DAL
{
    public class BaseRepository
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            string connectString = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=University;Integrated Security=True";
            con = new SqlConnection(connectString);
        }
    }
}
