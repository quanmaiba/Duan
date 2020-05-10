using AutoMapper;

namespace vaynhanh3s.BAL.Utility
{
    public sealed class DataTransformer
    {
        #region Private Static Object

        private static DataTransformer _instance;
        private static object _dtLocker = new object();

        #endregion


        #region Private Members

        private bool _hasInitMapping = false;
        private IMapper _mapper;

        #endregion


        #region Constructor

        private DataTransformer()
        {
        }

        #endregion


        #region Public Static Methods

        public static DataTransformer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_dtLocker)
                    {
                        _instance = new DataTransformer();
                    }
                }

                return _instance;
            }
        }

        #endregion


        #region Public Methods

        public void EnsureMapping()
        {
            if (!_hasInitMapping)
            {
                _hasInitMapping = true;

                SetupDataMapping();
            }
        }

        public IMapper GetMapper()
        {
            return _mapper;
        }

        #endregion


        #region Helper Methods

        private void SetupDataMapping()
        {
            _mapper = new MapperConfiguration(cfg =>
            {

                //cfg.CreateMap<SendEmailRequest, SDKSendEmailRequest>();

            }).CreateMapper();
        }

        #endregion
    }
}
