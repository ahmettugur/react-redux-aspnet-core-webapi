namespace ATCommon.Aspect.Contracts.Interception
{
    public interface IBeforeInterception : IInterception
    {
        object OnBefore(BeforeMethodArgs beforeMethodArgs);
    }
}
