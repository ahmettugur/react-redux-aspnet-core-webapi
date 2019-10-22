namespace ATCommon.Aspect.Contracts.Interception
{
    public interface IBeforeVoidInterception : IInterception
    {
        void OnBefore(BeforeMethodArgs beforeMethodArgs);
    }
}
