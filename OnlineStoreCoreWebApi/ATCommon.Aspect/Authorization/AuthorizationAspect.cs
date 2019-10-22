using ATCommon.Aspect.Contracts.Interception;
using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading;

namespace ATCommon.Aspect.Authorization
{
    public class AuthorizationAspect : InterceptionAttribute, IBeforeVoidInterception
    {
        public string Roles { get; set; }
        public void OnBefore(BeforeMethodArgs beforeMethodArgs)
        {
            if (string.IsNullOrWhiteSpace(Roles))
            {
                throw new Exception("Invalid roles");
            }

            var roles = Roles.Split(",");
            bool isAuthorize = false;

            foreach (var role in roles)
            {
                if (Thread.CurrentPrincipal.IsInRole(role))
                {
                    isAuthorize = true;
                    break;
                }
            }

            if (isAuthorize == false)
            {
                throw new SecurityException("You are not authorized");
            }
        }
    }
}
