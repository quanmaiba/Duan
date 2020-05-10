using vaynhanh3s.Contract;
using LBH.Common.TinyIoc;
using System.Collections.Generic;
using System.Reflection;

namespace vaynhanh3s.DI
{
    public class vaynhanh3sDIResolver : BaseResolver
    {
        public override void ConfigureAutoRegister(List<Assembly> assemblies)
        {
            assemblies.Add(typeof(AutoRegister).Assembly);
            assemblies.Add(typeof(DAL.AutoRegister).Assembly);
            assemblies.Add(typeof(BAL.AutoRegister).Assembly);
        }
    }
}
