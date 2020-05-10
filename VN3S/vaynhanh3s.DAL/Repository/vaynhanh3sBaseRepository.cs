using LBH.Common.Dapper;
using LBH.Common.Log4Net;
using LBH.Domain.Response;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using vaynhanh3s.Util;

namespace vaynhanh3s.DAL.Repository
{

    public class vaynhanh3sBaseRepository : BaseRepository
    {
        #region Private Members

        private readonly IDbTransaction _transaction;
        private readonly LoggingService _loggingService;

        #endregion


        #region Protected Members

        protected ILog GetLogger => _loggingService.GetLogger;

        #endregion


        #region Constructor

        protected vaynhanh3sBaseRepository(Type concreteType)
            : this(null, concreteType)
        {
        }

        protected vaynhanh3sBaseRepository(IDbTransaction transaction, Type concreteType)
        {
            _transaction = transaction;
            _loggingService = new LoggingService(concreteType);
        }

        #endregion


        #region Protected Methods

        protected async Task<Response<T>> ExecuteStoredProcSingleAsync<T>(SP name, object request, int? timeout = null)
        {
            var con = GetDbCon();
            try
            {
                var result = await ExecuteStoredProcAsync<T>(con, name.ToString(), request, _transaction, timeout);
                return new Response<T>() { Payload = result.FirstOrDefault() };
            }
            catch (Exception ex)
            {
                return new Response<T>() { Success = false, Error = new ErrorItem(ex.Message, ex) };
            }
            finally
            {
                if (_transaction == null)
                    con.Dispose();
            }
        }

        protected async Task<Response<IEnumerable<T>>> ExecuteStoredProcListAsync<T>(SP name, object request, int? timeout = null)
        {
            var con = GetDbCon();
            try
            {
                var result = await ExecuteStoredProcAsync<T>(con, name.ToString(), request, _transaction, timeout);
                return new Response<IEnumerable<T>>() { Payload = result };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<T>>() { Success = false, Error = new ErrorItem(ex.Message, ex) };
            }
            finally
            {
                if (_transaction == null)
                    con.Dispose();
            }
        }

        protected async Task<Response<dynamic>> ExecuteQueryMultipleAsync(SP name, object request, IEnumerable<MapItem> mapItems, int? timeout = null)
        {
            var con = GetDbCon();
            try
            {
                var result = await ExecuteQueryMultipleAsync(con, name.ToString(), request, _transaction, mapItems, timeout);
                return new Response<dynamic>() { Payload = result };
            }
            catch (Exception ex)
            {
                return new Response<dynamic>() { Success = false, Error = new ErrorItem(ex.Message, ex) };
            }
            finally
            {
                if (_transaction == null)
                    con.Dispose();
            }
        }

        #endregion


        #region Public Methods

        public IDbConnection GetDbCon()
        {
            if (_transaction != null)
                if (!string.IsNullOrWhiteSpace(_transaction.Connection.ConnectionString))
                    return _transaction.Connection;

            return GetDb(vaynhanh3sConfig.vaynhanh3sConnStr);
        }

        #endregion


        #region Enum

        protected enum SP
        {
            //Khách hàng
            proc_3s_CustomerRegister,
            proc_3s_GetCustomers,

            //Ứng cử viên
            proc_3s_CandidatorRegister,
            proc_3s_GetCandidators,

            //Banner
            proc_3s_Banner_Gets,
            proc_3s_Banner_Get,
            proc_3s_Banner_AddUpdate,

            //Điều kiện vay
            proc_3s_GetDieuKienVay,
            proc_3s_XoaDieuKienVay,
            proc_3s_KichHoatDieuKienVay,
            proc_3s_DieuKienVaySave


        }

        #endregion
    }
}
