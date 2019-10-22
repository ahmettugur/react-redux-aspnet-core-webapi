using ATCommon.Aspect.Contracts.Interception;
using ATCommon.Logging.Contracts;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ATCommon.Aspect.Logging
{
    public class ExceptionLogAspect : InterceptionAttribute, IExceptionInterception
    {
        private readonly Type _loggerType;
        private readonly ICommonLogger _logger;
        public ExceptionLogAspect(Type loggerType)
        {
            _loggerType = loggerType;
            if (!typeof(ICommonLogger).IsAssignableFrom(_loggerType))
            {
                throw new ArgumentException("Wrong logger type");
            }

            _logger = (ICommonLogger)Activator.CreateInstance(_loggerType);
        }
        public void OnException(ExceptionMethodArgs exceptionMethodArgs)
        {
            ParameterInfo[] parameterInfos = exceptionMethodArgs.MethodInfo.GetParameters();
            List<LogDetailParameter> logParameters = new List<LogDetailParameter>();
            for (int i = 0; i < exceptionMethodArgs.Arguments.Length; i++)
            {
                if (exceptionMethodArgs.Arguments[i] != null)
                {
                    var parameter = exceptionMethodArgs.Arguments[i].GetType().BaseType.BaseType == typeof(System.Linq.Expressions.LambdaExpression)
                                ? exceptionMethodArgs.Arguments[i].ToString()
                                : exceptionMethodArgs.Arguments[i];

                    logParameters.Add(new LogDetailParameter
                    {
                        Name = parameterInfos[i].Name,
                        Type = parameterInfos[i].ParameterType.Name,
                        Value = parameter
                    });
                }
                else
                {
                    logParameters.Add(new LogDetailParameter
                    {
                        Name = parameterInfos[i].Name,
                        Type = parameterInfos[i].ParameterType.Name,
                        Value = null
                    });
                }
            }

            LogDetail logDetail = new LogDetail
            {
                ClassName = exceptionMethodArgs.MethodInfo.DeclaringType.FullName,
                MethodName = exceptionMethodArgs.MethodInfo.Name,
                Parameters = logParameters,
                Message = exceptionMethodArgs.Exception.Message,
                InnerException = exceptionMethodArgs.Exception.InnerException == null ? "" : exceptionMethodArgs.Exception.InnerException.Message,
                StackStrace = exceptionMethodArgs.Exception.StackTrace
            };

            var jsonResult = JsonConvert.SerializeObject(logDetail, Formatting.Indented);
            LogMethodParameter logMethodParameter = new LogMethodParameter()
            {
                LogName = $"{exceptionMethodArgs.MethodInfo.Name}_err",
                Message = jsonResult
            };

            _logger.Log(logMethodParameter);
        }
    }
}
