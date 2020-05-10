using Dapper;
using Student.DAL.Interface;
using Student.Domain.Request.SinhVien;
using Student.Domain.Response.SinhVien;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Student.DAL
{
    public class SinhVienRepository : BaseRepository , ISinhVienRepository
    {
        public LuuSinhVienRes LuuSinhVien(LuuSinhVienReq luuSinhVienReq)
        {
            var result = new LuuSinhVienRes()
            {
                Result = 0,
                Message = "Đã xảy ra lỗi."
            };

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SinhVienId", luuSinhVienReq.SinhVienId);
                parameters.Add("@TenSV", luuSinhVienReq.TenSV);
                parameters.Add("@QueQuan", luuSinhVienReq.QueQuan);
                parameters.Add("@GioiTinh", luuSinhVienReq.GioiTinh);
                parameters.Add("@LopId", luuSinhVienReq.LopId);

                var response = SqlMapper.ExecuteScalar<int>(con, "sp_LuuSinhVien", param: parameters, commandType: System.Data.CommandType.StoredProcedure);

                result.Result = response;
                if (result.Result != 0)
                {
                    result.Message = luuSinhVienReq.SinhVienId != 0 ? "Đã cập nhật sinh viên thành công." : "Đã thêm sinh viên thành công.";
                }

                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public XoaSinhVienRes XoaSinhVien(XoaSinhVienReq xoaSinhVienReq)
        {
            var result = new XoaSinhVienRes()
            {
                Result = 0,
                Message = "Đã xảy ra lỗi"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SinhVienId", xoaSinhVienReq.SinhVienId);
                var response = SqlMapper.ExecuteScalar<int>(con, "sp_XoaSinhVien", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                result.Result = response;
                if (result.Result != 0)
                {
                    result.Message = "Đã xóa sinh viên thành công";
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        public LaySVTheoIdRes LaySVTheoId(LaySVTheoIdReq laySVTheoIdReq)
        {
            var result = new LaySVTheoIdRes()
            {
                Result = 0,
                Message = "Lỗi"
            };
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@SinhVienId", laySVTheoIdReq.SinhVienId);
                int response = SqlMapper.ExecuteScalar<int>(con, "sp_LaySVTheoId", param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                result.Result = response;
                result.Message = "Get successfully";
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
    }
}
