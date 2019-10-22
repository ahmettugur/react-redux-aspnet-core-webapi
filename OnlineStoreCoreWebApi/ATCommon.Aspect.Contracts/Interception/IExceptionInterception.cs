namespace ATCommon.Aspect.Contracts.Interception
{
    public interface IExceptionInterception : IInterception
    {
        void OnException(ExceptionMethodArgs exceptionMethodArgs);
    }
}
