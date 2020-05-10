namespace vaynhanh3s.DI
{
    public static class DIResolver
    {
        #region Private Members

        private static readonly vaynhanh3sDIResolver _resolver = new vaynhanh3sDIResolver();
        private static readonly object HCIDiLock = new object();

        #endregion


        #region Public

        public static bool HasConfigured => _resolver.Initialized;

        public static void ConfigureDI()
        {
            lock (HCIDiLock)
            {
                if (!HasConfigured)
                    _resolver.Initialize();
            }
        }

        public static void Register<TInt, TImpl>()
            where TInt : class
            where TImpl : class, TInt
        {
            _resolver.Register<TInt, TImpl>();
        }

        public static T Resolve<T>() where T : class
        {
            return _resolver.Resolve<T>();
        }

        #endregion
    }
}
