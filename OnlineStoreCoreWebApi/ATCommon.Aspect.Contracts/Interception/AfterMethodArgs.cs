using System.Reflection;

namespace ATCommon.Aspect.Contracts.Interception
{
    public class AfterMethodArgs : InterceptionArgs
    {

        public object Value { get; protected set; }

        public AfterMethodArgs(MethodInfo methodInfo,  object[] arguments)
            : base(methodInfo, arguments)
        {
        }

        public AfterMethodArgs(InterceptionArgs interceptionArgs) : base(interceptionArgs) { }

        public AfterMethodArgs(InterceptionArgs interceptionArgs, object val) : this(interceptionArgs)
        {
            Value = val;
        }
    }
}
