using System;
using System.Reflection;
using System.Text;

namespace ATCommon.Aspect.Contracts.Interception
{
    public class ExceptionMethodArgs : InterceptionArgs
    {

        public Exception Exception { get; set; }

        public ExceptionMethodArgs(MethodInfo methodInfo, object[] arguments)
            : base(methodInfo, arguments)
        {
        }

        public ExceptionMethodArgs(InterceptionArgs interceptionArgs) : base(interceptionArgs) { }

        public ExceptionMethodArgs(InterceptionArgs interceptionArgs, Exception ex)
            : this(interceptionArgs)
        {
            Exception = ex;
        }
    }
}
