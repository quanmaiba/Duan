using LBH.Common.Log4Net;
using LBH.Domain;
using LBH.Domain.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransformer = vaynhanh3s.BAL.Utility.DataTransformer;

namespace vaynhanh3s.BAL.Service
{
    public abstract class BaseService : LoggingService
    {
        #region Constructor

        protected BaseService(Type concreteType) :
            base(concreteType)
        {
            DataTransformer.Instance.EnsureMapping();
        }

        #endregion


        #region Protected Methods

        protected TInterface ToObjectInterface<TSource, TOutput, TInterface>(TSource source) where TInterface : class
        {
            return DataTransformer.Instance.GetMapper().Map<TOutput>(source) as TInterface;
        }

        protected TOutput ToDataType<TSource, TOutput>(TSource source)
        {
            return DataTransformer.Instance.GetMapper().Map<TOutput>(source);
        }

        protected async Task<Response<T>> RunMethodAsync<T>(Func<Task<Response<T>>> taskMethod)
        {
            try
            {
                var result = await taskMethod();

                if (!result.Success)
                    return new Response<T>() { Success = false, Error = result.Error };

                result.ResponseCode = (int)ResponseCode.Success;
                return result;
            }
            catch (Exception ex)
            {
                GetLogger.Error("RunMethod Exception", ex);
                return new Response<T>() { Success = false, Error = new ErrorItem(ex.Message, ex) };
            }
        }

        protected void ThrowError(ErrorItem error)
        {
            if (error == null)
                return;

            throw new ArgumentException(error.Message, error.Exception);
        }

        protected void LogErrorItem(ErrorItem error)
        {
            if (error != null)
            {
                if (!string.IsNullOrWhiteSpace(error.Message))
                {
                    if (error.Exception != null)
                    {
                        GetLogger.Error(error.Message, error.Exception);
                    }
                    else
                    {
                        GetLogger.Error(error.Message);
                    }
                } else if (error.Exception != null)
                {
                    GetLogger.Error("Error occur", error.Exception);
                }
            }
        }

        protected List<T> GetTypedList<T>(dynamic source)
        {
            return ((List<object>)source).Select(s => (T)s).ToList();
        }

        protected string CleanupMobile(string countryCode, string phoneNumber)
        {
            var registerMobile = phoneNumber;

            if (!string.IsNullOrWhiteSpace(registerMobile) && !registerMobile.StartsWith("#"))
            {
                if (registerMobile.StartsWith("0"))
                    registerMobile = registerMobile.TrimStart('0');

                registerMobile = (string.IsNullOrWhiteSpace(countryCode) ? "" : countryCode) + registerMobile;
                registerMobile = registerMobile.Replace(" ", "").Replace("+", "");
            }


            return registerMobile;
        }

        #endregion

    }
}
