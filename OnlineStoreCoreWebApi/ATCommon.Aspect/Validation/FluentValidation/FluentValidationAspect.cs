using FluentValidation;
using ATCommon.Aspect.Contracts.Interception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATCommon.Aspect.Validation.FluentValidation
{
    public class FluentValidationAspect : InterceptionAttribute, IBeforeVoidInterception
    {
        private Type _validatorType;

        public FluentValidationAspect(Type validatorType)
        {
            _validatorType = validatorType;
        }
        public void OnBefore(BeforeMethodArgs beforeMethodArgs)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var entities = beforeMethodArgs.Arguments.Where(_ => _.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidatorTool.FluentValidate(validator, entity);
            }
        }
    }
}
