using Dapper;
using QLSV.DAL_Interface;
using QLSV.Domain.Request.GiaoVien;
using QLSV.Domain.Response.GiaoVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace QLSV.DAL
{
    public class GiaoVienRepository : BaseRepository, IGiaoVienRepository
    {

        public IList<GiaoVienItem> LayDanhSachGiaoVien()
        {
            IList<GiaoVienItem> danhSachGiaoVien = SqlMapper.Query<GiaoVienItem>(con, "proc_LayDanhSachGiaoVien", null,
                 commandType: CommandType.StoredProcedure).ToList();

            return danhSachGiaoVien;
        }

        public GiaoVienItem LayGiaoVien(int giaoVienId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@GiaoVienId", giaoVienId);
            GiaoVienItem giaoVien = SqlMapper.Query<GiaoVienItem>(con, "proc_LayGiaoVienTheoId", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return giaoVien;
        }

        public LuuGiaoVienRes LuuGiaoVien(LuuGiaoVienReq luuGiaoVienReq)
        {
            var result = new LuuGiaoVienRes()
            {
                Result = 0,
                Message = $"Lỗi, vui lòng thử lại"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@GiaoVienId", luuGiaoVienReq.GiaoVienId);
                parameters.Add("@HoTenGV", luuGiaoVienReq.HoTenGV);
                parameters.Add("@GioiTinh", luuGiaoVienReq.GioiTinh);
                parameters.Add("@DOB", luuGiaoVienReq.DOB);
                parameters.Add("@Img", luuGiaoVienReq.Img);
                parameters.Add("@Email", luuGiaoVienReq.Email);
                parameters.Add("@DiaChi", luuGiaoVienReq.DiaChi);


                var response = SqlMapper.ExecuteScalar<int>(con, "LuuGiaoVien",
                                        param: parameters,
                                        commandType: CommandType.StoredProcedure);
                result.Result = response;
                result.Message = luuGiaoVienReq.GiaoVienId != 0 ?
                                    $"Lớp đã được cập nhật thành công." :
                                    $"Lớp đã được thêm thành công.";
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public int XoaGiaoVien(int giaoVienId)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@GiaoVienId ", giaoVienId);
                var result = SqlMapper.ExecuteScalar<int>(con, "proc_XoaGiaoVienTheoId", param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
