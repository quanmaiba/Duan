using LBH.Domain.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using vaynhanh3s.Contract.Repository;
using vaynhanh3s.Domain.Request.Banner;
using vaynhanh3s.Domain.Request.Candidator;
using vaynhanh3s.Domain.Request.Customer;
using vaynhanh3s.Domain.Request.DieuKienVay;
using vaynhanh3s.Domain.Response.Banner;
using vaynhanh3s.Domain.Response.Candidator;
using vaynhanh3s.Domain.Response.Customer;
using vaynhanh3s.Domain.Response.DieuKienVay;

namespace vaynhanh3s.DAL.Repository
{
    public class vaynhanh3sRepository : vaynhanh3sBaseRepository, Ivaynhanh3sRepository
    {
        #region Constructor

        public vaynhanh3sRepository() : base(typeof(vaynhanh3sRepository))
        {
        }

        #endregion


        #region Public Methods


        #region Banner
        public async Task<Response<IEnumerable<GetsResult>>> BannerGets(GetsRequest request)
        {
            return await ExecuteStoredProcListAsync<GetsResult>(SP.proc_3s_Banner_Gets, request);
        }

        public async Task<Response<GetResult>> BannerGet(GetRequest request)
        {
            return await ExecuteStoredProcSingleAsync<GetResult>(SP.proc_3s_Banner_Get, request);
        }

        public async Task<Response<AddUpdateResult>> BannerAddUpdate(AddUpdateRequest request)
        {
            return await ExecuteStoredProcSingleAsync<AddUpdateResult>(SP.proc_3s_Banner_AddUpdate, request);
        }

        public async Task<Response<CustomerRegisterResult>> CustomerRegister(SpCustomerRegister request)
        {
            return await ExecuteStoredProcSingleAsync<CustomerRegisterResult>(SP.proc_3s_CustomerRegister, request);
        }

        public async Task<Response<IEnumerable<Customer>>> GetCustomers(GetCustomers request)
        {
            return await ExecuteStoredProcListAsync<Customer>(SP.proc_3s_GetCustomers, request);
        }

        public async Task<Response<CandidatorRegisterResult>> CandidatorRegister(SpCandidatorRegister request)
        {
            return await ExecuteStoredProcSingleAsync<CandidatorRegisterResult>(SP.proc_3s_CandidatorRegister, request);
        }

        public async Task<Response<IEnumerable<Candidator>>> GetCandidators(GetCandidators request)
        {
            return await ExecuteStoredProcListAsync<Candidator>(SP.proc_3s_GetCandidators, request);
        }

        public async Task<Response<IEnumerable<DieuKienVay>>> GetDieuKienVay(GetDieuKienVay request)
        {
            return await ExecuteStoredProcListAsync<DieuKienVay>(SP.proc_3s_GetDieuKienVay, request);
        }

        public async Task<Response<DieuKienVaySaveResult>> DieuKienVaySave(DieuKienVaySaveRequest request)
        {
            return await ExecuteStoredProcSingleAsync<DieuKienVaySaveResult>(SP.proc_3s_DieuKienVaySave, request);
        }

        public async Task<Response<KichHoatDieuKienVayResult>> KichHoatDieuKienVay(KichHoatDieuKienVayRequest request)
        {
            return await ExecuteStoredProcSingleAsync<KichHoatDieuKienVayResult>(SP.proc_3s_KichHoatDieuKienVay, request);
        }

        public async Task<Response<XoaDieuKienVayResult>> XoaDieuKienVay(XoaDieuKienVayRequest request)
        {
            return await ExecuteStoredProcSingleAsync<XoaDieuKienVayResult>(SP.proc_3s_XoaDieuKienVay, request);
        }

        #endregion

        #endregion
    }
}
