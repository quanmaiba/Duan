using System.Data;
using System.Data.SqlClient;

namespace Student.DAL
{
    public class BaseRepository
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            string connectString = @"Server=DESKTOP-NTNOUNK;User ID=sa;Password=123456;Database=SinhVienDB;Trusted_Connection=True;";

            //string connectString = @"Data Source=DESKTOP-A5B5UBC\SQLEXPRESS;Initial Catalog=SinhVienDB;Integrated Security=True";
            con = new SqlConnection(connectString);
        }
    }
}
