using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using University.DAL.Interface;
using University.Domain.Request.Lop;
using University.Domain.Response.Lop;

namespace University.DAL
{
    public class LopRepository : BaseRepository, ILopRepository
    {
        public IList<LopItem> LayDanhSachLop()
        {
            IList<LopItem> danhSachLop = SqlMapper.Query<LopItem>(con, "proc_GetClasses", null, 
                commandType: CommandType.StoredProcedure).ToList();
            return danhSachLop;
        }

        public LuuLopRes LuuLop(LuuLopReq luuLopReq)
        {
            var result = new LuuLopRes() { 
                Result = 0,
                Message = $"Lỗi, vui lòng thử lại"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@LopId", luuLopReq.LopId);
                parameters.Add("@TenLop", luuLopReq.TenLop);
                var response = SqlMapper.ExecuteScalar<int>(con, "proc_SaveClass",
                                        param: parameters,
                                        commandType: CommandType.StoredProcedure);
                result.Result = response;
                result.Message = luuLopReq.LopId != 0 ?
                                    $"Lớp đã được cập nhật thành công." :
                                    $"Lớp đã được thêm thành công.";
                return result;
            }
            catch (Exception ex)
            { 
                return result;
            }
        }
    }
}
