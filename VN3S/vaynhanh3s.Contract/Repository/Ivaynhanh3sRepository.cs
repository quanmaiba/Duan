using LBH.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using vaynhanh3s.Domain.Request.Banner;
using vaynhanh3s.Domain.Request.Candidator;
using vaynhanh3s.Domain.Request.Customer;
using vaynhanh3s.Domain.Request.DieuKienVay;
using vaynhanh3s.Domain.Response.Banner;
using vaynhanh3s.Domain.Response.Candidator;
using vaynhanh3s.Domain.Response.Customer;
using vaynhanh3s.Domain.Response.DieuKienVay;

namespace vaynhanh3s.Contract.Repository
{
    public interface Ivaynhanh3sRepository
    {
        #region Banner

        Task<Response<IEnumerable<GetsResult>>> BannerGets(GetsRequest request);
        Task<Response<GetResult>> BannerGet(GetRequest request);
        Task<Response<AddUpdateResult>> BannerAddUpdate(AddUpdateRequest request);

        #endregion

        #region Customer

        Task<Response<CustomerRegisterResult>> CustomerRegister(SpCustomerRegister request);
        Task<Response<IEnumerable<Customer>>> GetCustomers(GetCustomers request);

        #endregion

        #region Candidator

        Task<Response<CandidatorRegisterResult>> CandidatorRegister(SpCandidatorRegister request);
        Task<Response<IEnumerable<Candidator>>> GetCandidators(GetCandidators request);
        #endregion

        #region Điều kiện vay

        Task<Response<IEnumerable<DieuKienVay>>> GetDieuKienVay(GetDieuKienVay request);
        Task<Response<DieuKienVaySaveResult>> DieuKienVaySave(DieuKienVaySaveRequest request);
        Task<Response<KichHoatDieuKienVayResult>> KichHoatDieuKienVay(KichHoatDieuKienVayRequest request);
        Task<Response<XoaDieuKienVayResult>> XoaDieuKienVay(XoaDieuKienVayRequest request);

        #endregion
    }
}
