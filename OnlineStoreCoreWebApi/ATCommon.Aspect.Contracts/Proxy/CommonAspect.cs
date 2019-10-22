using ATCommon.Aspect.Contracts;
using ATCommon.Aspect.Contracts.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ATCommon.Aspect.Contracts.Proxy
{
    public class CommonAspect<T> : DispatchProxy
    {
        private T _service;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            object[] interceptions = null;
            InterceptionArgs interceptionArgs = null;
            try
            {

                interceptionArgs = CreateAspectArgs(targetMethod, args);
                interceptions = GetInterceptions(targetMethod);

                // BeforeMethodArgs çalıştırılır. Cache vb. gelen datalar result değişkenine aktarılır
                BeforeMethodArgs beforeMethodArgs = new BeforeMethodArgs(interceptionArgs);
                object result = RunOnBeforeInterception(interceptions, beforeMethodArgs);
                //result dolu ise ilgili methodun çalışmasına gerek yoktur
            
                if (result == null)
                {
                    //result null ise ilgili method çalıştırılır.
                    result = targetMethod.Invoke(_service, args);
                }

                //After İnterceptionlar çalıştırılır
                AfterMethodArgs afterMethodArgs = new AfterMethodArgs(interceptionArgs);
                RunOnAfterInterception(interceptions, new AfterMethodArgs(afterMethodArgs, result));
                //RunOnAfterInterception(interceptions, new AfterMethodArgs(interceptionArgs, result));

                return result;
            }
            catch (Exception ex)
            {

                var exArg = new ExceptionMethodArgs(interceptionArgs, ex);
                RunOnExceptionInterception(interceptions, exArg);
                throw ex.InnerException ?? ex;  
                //return null;
            }
            //catch (Exception ex) when (ex is TargetInvocationException)
            //{

            //    var exArg = new ExceptionMethodArgs(e,ex);
            //    RunOnExceptionInterception(interceptions, exArg);
            //    //throw ex.InnerException ?? ex;  
            //    return null;
            //}
        }
        public static T Create(T service)
        {

            object proxy = Create<T, CommonAspect<T>>();
            ((CommonAspect<T>)proxy).SetParameters(service);


            return (T)proxy;
        }
        //public static T Create(T decorated, ICommonLogger logger)
        //{
        //    _logger = logger;
        //    object proxy = Create<T, CommonAspect<T>>();
        //    ((CommonAspect<T>)proxy).SetParameters(decorated);

        //    return (T)proxy;
        //}

        private void SetParameters(T services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            _service = services;
        }

        private InterceptionArgs CreateAspectArgs(MethodInfo methodInfo, object[] args)
        {
            var realType = _service.GetType();
            MethodInfo mInfo = realType.GetMethod(methodInfo.Name);
            InterceptionArgs interceptionArgs = new InterceptionArgs(mInfo, args);
            return interceptionArgs;
        }

        /// <summary>
        /// Metdoda eklenmiş Interception'larımızı buluyoruz.
        /// </summary>
        /// <param name="methodCallMessage"></param>
        /// <returns></returns>
        private object[] GetInterceptions(MethodInfo methodInfo)
        {
           
            var realType = _service.GetType();
            MethodInfo mInfo = realType.GetMethod(methodInfo.Name);
            object[] methodAttribute = mInfo.GetCustomAttributes(typeof(IInterception), true);
            object[] classAttribute = realType.GetCustomAttributes(typeof(IInterception), true);
            var totalAttribute = methodAttribute.Concat(classAttribute);
            return totalAttribute.ToArray();
        }

        private object RunOnBeforeInterception(object[] aspects, BeforeMethodArgs beforeMethodArgs)
        {
            object response = null;
            foreach (IInterception loopAttribute in aspects)
            {
                if (loopAttribute is IBeforeVoidInterception)
                {
                    ((IBeforeVoidInterception)loopAttribute).OnBefore(beforeMethodArgs);
                }
                else if (loopAttribute is IBeforeInterception)
                {
                    response = ((IBeforeInterception)loopAttribute).OnBefore(beforeMethodArgs);
                }
            }
            return response;
        }
        private void RunOnAfterInterception(object[] aspects, AfterMethodArgs afterMethodArgs)
        {
            foreach (IInterception loopAttribute in aspects)
            {
                if (loopAttribute is IAfterInterception)
                {
                    ((IAfterInterception)loopAttribute).OnAfter(afterMethodArgs);
                }
            }
        }

        private void RunOnExceptionInterception(object[] aspects, ExceptionMethodArgs exceptionMethodArgs)
        {
            if (aspects == null)
                return;

            foreach (IInterception loopAttribute in aspects)
            {
                if (loopAttribute is IExceptionInterception)
                {
                    ((IExceptionInterception)loopAttribute).OnException(exceptionMethodArgs);
                }
            }
        }
    }
}
