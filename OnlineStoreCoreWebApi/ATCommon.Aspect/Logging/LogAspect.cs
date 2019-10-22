using Newtonsoft.Json;
using ATCommon.Aspect.Contracts;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ATCommon.Aspect.Contracts.Interception;
using ATCommon.Logging.Contracts;

namespace ATCommon.Aspect.Logging
{
    public class LogAspect : InterceptionAttribute, IBeforeVoidInterception, IAfterInterception
    {
        private readonly Type _loggerType;
        private readonly ICommonLogger _logger;

        public LogAspect(Type loggerType)
        {

            _loggerType = loggerType;

            if (!typeof(ICommonLogger).IsAssignableFrom(_loggerType))
            {
                throw new Exception("Wrong logger type");
            }

            _logger = (ICommonLogger)Activator.CreateInstance(_loggerType);
        }

        public void OnBefore(BeforeMethodArgs beforeMethodArgs)
        {
            LogMethodParameter logMethodParameter = null;

            ParameterInfo[] parameterInfos = beforeMethodArgs.MethodInfo.GetParameters();
            List<LogDetailParameter> logParameters = new List<LogDetailParameter>();
            for (int i = 0; i < beforeMethodArgs.Arguments.Length; i++)
            {
                if (beforeMethodArgs.Arguments[i] != null)
                {
                    var parameter = beforeMethodArgs.Arguments[i].GetType().BaseType.BaseType == typeof(System.Linq.Expressions.LambdaExpression)
                    ? beforeMethodArgs.Arguments[i].ToString()
                    : beforeMethodArgs.Arguments[i];

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
                ClassName = beforeMethodArgs.MethodInfo.DeclaringType.FullName,
                MethodName = beforeMethodArgs.MethodInfo.Name,
                Parameters = logParameters
            };

           
            logMethodParameter = new LogMethodParameter()
            {
                LogName = beforeMethodArgs.MethodInfo.Name,
                LogDetail = logDetail
            };

            _logger.Log(logMethodParameter);
        }

        public void OnAfter(AfterMethodArgs afterMethodArgs)
        {
            LogMethodParameter logMethodParameter = null;

            ParameterInfo[] parameterInfos = afterMethodArgs.MethodInfo.GetParameters();
            List<LogDetailParameter> logParameters = new List<LogDetailParameter>();
            for (int i = 0; i < afterMethodArgs.Arguments.Length; i++)
            {
                if (afterMethodArgs.Arguments[i] != null)
                {
                    var parameter = afterMethodArgs.Arguments[i].GetType().BaseType.BaseType == typeof(System.Linq.Expressions.LambdaExpression)
                                    ? afterMethodArgs.Arguments[i].ToString()
                                    : afterMethodArgs.Arguments[i];

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
                ClassName = afterMethodArgs.MethodInfo.DeclaringType.FullName,
                MethodName = afterMethodArgs.MethodInfo.Name,
                Parameters = logParameters,
                Result = afterMethodArgs.Value
            };

            logMethodParameter = new LogMethodParameter()
            {
                LogName = afterMethodArgs.MethodInfo.Name,
                LogDetail = logDetail
            };

            _logger.Log(logMethodParameter);
        }
    }

}
