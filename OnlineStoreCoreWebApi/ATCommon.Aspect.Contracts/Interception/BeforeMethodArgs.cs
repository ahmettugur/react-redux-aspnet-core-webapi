using System.Reflection;

namespace ATCommon.Aspect.Contracts.Interception
{
    public class BeforeMethodArgs : InterceptionArgs
    {
        public BeforeMethodArgs(MethodInfo methodInfo, object[] arguments)
            : base(methodInfo, arguments)
        {
        }

        public BeforeMethodArgs(InterceptionArgs interceptionArgs) : base(interceptionArgs) { }

    }
}
