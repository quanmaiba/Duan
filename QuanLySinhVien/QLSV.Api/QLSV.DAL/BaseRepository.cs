using System.Data;
using System.Data.SqlClient;

namespace QLSV.DAL
{
    public class BaseRepository
    {
        protected IDbConnection con;
        public BaseRepository()
        {

            string connectString = @"Server=DESKTOP-NTNOUNK;User ID=sa;Password=123456;Database=SinhVienDB;Trusted_Connection=True;";
            con = new SqlConnection(connectString);
        }
    }
}
//Data Source = DESKTOP - NTNOUNK; Initial Catalog = QuanLySinhVien; User ID = sa; Password=********;Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False