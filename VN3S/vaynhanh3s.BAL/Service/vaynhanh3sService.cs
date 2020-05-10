using LBH.Domain.Response;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using vaynhanh3s.Contract.Repository;
using vaynhanh3s.Contract.Service;
using vaynhanh3s.Domain.Request.Banner;
using vaynhanh3s.Domain.Request.Candidator;
using vaynhanh3s.Domain.Request.Customer;
using vaynhanh3s.Domain.Request.DieuKienVay;
using vaynhanh3s.Domain.Request.Email;
using vaynhanh3s.Domain.Response.Banner;
using vaynhanh3s.Domain.Response.Candidator;
using vaynhanh3s.Domain.Response.Customer;
using vaynhanh3s.Domain.Response.DieuKienVay;
using vaynhanh3s.Domain.Response.ReCaptcha;
using vaynhanh3s.Util;
using static vaynhanh3s.Util.DonHang;

namespace vaynhanh3s.BAL.Service
{
    public class vaynhanh3sService : BaseService, Ivaynhanh3sService
    {
        #region Private Members

        private readonly Ivaynhanh3sRepository _repository;

        #endregion


        #region Constructor

        public vaynhanh3sService(Ivaynhanh3sRepository repository) :
            base(typeof(vaynhanh3sService))
        {
            _repository = repository;
        }

        #endregion


        #region Public Methods


        #region Banner
        public async Task<Response<IEnumerable<GetsResult>>> BannerGets(GetsRequest request)
        {
            return await RunMethodAsync(async () => await _repository.BannerGets(request));
        }

        public async Task<Response<GetResult>> BannerGet(GetRequest request)
        {
            return await RunMethodAsync(async () => await _repository.BannerGet(request));
        }

        public async Task<Response<AddUpdateResult>> BannerAddUpdate(AddUpdateRequest request)
        {
            var response = new Response<AddUpdateResult> { Payload = new AddUpdateResult { Result = 0, Message = GeneralMessage.SomeThingWentWrong } };
            var result = await _repository.BannerAddUpdate(request);
            if (result.Success && result.Payload != null && result.Payload.Result == 1)
            {
                response.Payload.Result = 1;
                response.Payload.Message = request.Id > 0 ? Banner.UpdateSuccess : Banner.AddSuccess;
            }

            return response;
        }

        public async Task<Response<CustomerRegisterResult>> CustomerRegister(CustomerRegister request)
        {
            var result = new Response<CustomerRegisterResult>()
            {
                Payload = new CustomerRegisterResult()
                {
                    Message = "Hệ thống đang bảo trì, quý khách vui lòng đăng ký lại sau hoặc liên lạc với chúng tôi qua hotline.",
                    Success = false
                }
            };
            if (bool.Parse(vaynhanh3sConfig.EnableCaptcha))
            {  
                if (string.IsNullOrEmpty(request.GRecaptchaResponse))
                {
                    return result;
                }
                if (!CaptchaValidate(request.GRecaptchaResponse).Success)
                {
                    result.Payload.Message = "Việc đăng ký của bạn không hợp lệ!";
                    return result;
                }

            }
            var registerResult = await _repository.CustomerRegister(new SpCustomerRegister()
            {
                DieuKienVayId = request.DieuKienVayId,
                HoTen = request.HoTen,
                SoCMND = request.SoCMND,
                SoDienThoai = request.SoDienThoai,
                TinhThanhId = request.TinhThanhId
            });

            if(registerResult.Success && registerResult.Payload != null && registerResult.Payload.Success)
            {
                var dieuKienVay = await DieuKienVay(request.DieuKienVayId);
                var thanhPho = request.TinhThanhId == 46 ? "Tỉnh Thừa Thiên Huế" : "Thành Phố Đà Nẵng";
                var sendEmail = EmailService.Send(new SendEmailRequest()
                {
                    AdminEmailList = new List<string>() { },
                    body = $"Thông tin Khách hàng đăng ký vay: <br>" +
                            $"+ Họ tên: {request.HoTen} <br>" +
                            $"+ Số điện thoại: {request.SoDienThoai} <br>" +
                            $"+ Số CMND: {request.SoCMND} <br>" +
                            $"+ Điều kiện vay: {dieuKienVay} <br>" +
                            $"+ Thành Phố: { thanhPho } <br>",
                    subject = "Khách hàng đăng ký vay",
                    template = "",
                    ToEmail = vaynhanh3sConfig.ReceiverEmail
                }) ;

                result.Payload.Success = registerResult.Success && registerResult.Payload.Success;
                result.Payload.Message = registerResult.Payload.Message;
            }
            return result;
        }

        public async Task<Response<IEnumerable<Customer>>> GetCustomers(GetCustomers request)
        {
            return await RunMethodAsync(async () => await _repository.GetCustomers(request));
        }

        public async Task<Response<CandidatorRegisterResult>> CandidatorRegister(CandidatorRegister request)
        {
            var result = new Response<CandidatorRegisterResult>()
            {
                Payload = new CandidatorRegisterResult()
                {
                    Message = "Hệ thống đang bảo trì, quý khách vui lòng đăng ký lại sau hoặc liên lạc với chúng tôi qua hotline.",
                    Success = false
                }
            };
            if (bool.Parse(vaynhanh3sConfig.EnableCaptcha))
            {
                if (string.IsNullOrEmpty(request.GRecaptchaResponse))
                {
                    return result;
                }
                if (!CaptchaValidate(request.GRecaptchaResponse).Success)
                {
                    result.Payload.Message = "Việc đăng ký của bạn không hợp lệ!";
                    return result;
                }

            }

            var applyResult = await _repository.CandidatorRegister(new SpCandidatorRegister()
            {
                VitriId = request.VitriId,
                HoTen = request.HoTen,
                SoCMND = request.SoCMND,
                SoDienThoai = request.SoDienThoai,
                TinhThanhId = request.TinhThanhId
            });
            if (applyResult.Success && applyResult.Payload != null && applyResult.Payload.Success)
            {
                var viTri = request.VitriId == 1 ? "Nhân viên kinh doanh" : "Giám sát phát triển kinh doanh";
                var thanhPho = request.TinhThanhId == 46 ? "Tỉnh Thừa Thiên Huế" : "Thành Phố Đà Nẵng";
                var sendEmail = EmailService.Send(new SendEmailRequest()
                {
                    AdminEmailList = new List<string>() { },
                    body = $"Thông tin ứng cử viên đăng ký tuyển dụng: <br>" +
                            $"+ Họ tên: {request.HoTen} <br>" +
                            $"+ Số điện thoại: {request.SoDienThoai} <br>" +
                            $"+ Số CMND: {request.SoCMND} <br>" +
                            $"+ Vị trí ứng tuyển: {viTri} <br>" +
                            $"+ Thành Phố: { thanhPho } <br>",
                    subject = "Ứng cử viên đăng ký tuyển dụng",
                    template = "",
                    ToEmail = vaynhanh3sConfig.ReceiverEmail
                });

                result.Payload.Success = applyResult.Success && applyResult.Payload.Success;
                result.Payload.Message = applyResult.Payload.Message;
            }
            return result;
        }

        public async Task<Response<IEnumerable<Candidator>>> GetCandidators(GetCandidators request)
        {
            return await RunMethodAsync(async () => await _repository.GetCandidators(request));
        }

        public async Task<Response<IEnumerable<DieuKienVay>>> GetDieuKienVay(GetDieuKienVay request)
        {
            return await RunMethodAsync(async () => await _repository.GetDieuKienVay(request));
        }

        #endregion
        #endregion

        private static ReCaptcha CaptchaValidate(string gRecaptchaResponse)
        {
            var client = new System.Net.WebClient();

            var googleReply = client.DownloadString(string.Format(vaynhanh3sConfig.GoogleAPI,
                vaynhanh3sConfig.GSecretKey, gRecaptchaResponse));
            var captchaResponse = JsonConvert.DeserializeObject<ReCaptcha>(googleReply);

            return captchaResponse;
        }

        private async Task<string> DieuKienVay(int dieuKienVayId)
        {
            var dieuKienVay = await _repository.GetDieuKienVay(new GetDieuKienVay()
            {
                DieuKienVayId = dieuKienVayId
            });
            return dieuKienVay.Payload.FirstOrDefault().Ten;
        }

        public async Task<Response<DieuKienVaySaveResult>> DieuKienVaySave(DieuKienVaySaveRequest request)
        {
            return await RunMethodAsync(async () => await _repository.DieuKienVaySave(request));
        }

        public async Task<Response<KichHoatDieuKienVayResult>> KichHoatDieuKienVay(KichHoatDieuKienVayRequest request)
        {
            return await RunMethodAsync(async () => await _repository.KichHoatDieuKienVay(request));
        }

        public async Task<Response<XoaDieuKienVayResult>> XoaDieuKienVay(XoaDieuKienVayRequest request)
        {
            return await RunMethodAsync(async () => await _repository.XoaDieuKienVay(request));
        }
    }
}
