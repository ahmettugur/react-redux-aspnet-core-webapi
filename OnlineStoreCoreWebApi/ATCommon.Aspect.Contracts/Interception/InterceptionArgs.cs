using System;
using System.Reflection;
using System.Text;

namespace ATCommon.Aspect.Contracts.Interception
{
    public class InterceptionArgs
    {
        public MethodInfo MethodInfo { get; protected set; }
        public object[] Arguments { get; protected set; }

        public InterceptionArgs(MethodInfo methodInfo, object[] arguments)
        {
            MethodInfo = methodInfo;
            Arguments = arguments;
        }

        public InterceptionArgs(InterceptionArgs interceptionArgs)
            : this(interceptionArgs.MethodInfo, interceptionArgs.Arguments)
        {

        }
    }
}
