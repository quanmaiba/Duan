using Dapper;
using QLNV.DAL.Interface;
using QLNV.Domain;
using QLNV.Domain.Request;
using QLNV.Domain.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLNV.DAL
{
    public class PhongBanRepository : BaseRepository, IPhongBanRepository
    {
        public IList<PhongBan> DanhSachPhongBan()
        {
            IList<PhongBan> danhSachPhongBan = SqlMapper.Query<PhongBan>(con, "DanhSachPhongBan", commandType: CommandType.StoredProcedure).ToList();
            return danhSachPhongBan;
        }

        public PhongBan LayPhongBanID(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            PhongBan phongBan = SqlMapper.Query<PhongBan>(con, "LayPhongBanID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return phongBan;
        }

        public int SuaPhongBan(SuaPhongBan request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", request.Id);
                parameters.Add("@MaPhongBan ", request.MaPhongBan);
                parameters.Add("@TenPhongBan", request.TenPhongBan);
                var id =  SqlMapper.ExecuteScalar<int>(con, "SuaPhongBan", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
                //throw ex;
            }
        }

        public int TaoPhongBan(TaoPhongBan request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaPhongBan ", request.MaPhongBan);
                parameters.Add("@TenPhongBan", request.TenPhongBan);
                var id = SqlMapper.ExecuteScalar<int>(con, "TaoPhongBan", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaPhongBan(int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id ", Id);
                var result = SqlMapper.ExecuteScalar<bool>(con, "XoaPhongBan", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
