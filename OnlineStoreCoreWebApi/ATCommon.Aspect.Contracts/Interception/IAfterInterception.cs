namespace ATCommon.Aspect.Contracts.Interception
{
    public interface IAfterInterception : IInterception
    {
       void OnAfter(AfterMethodArgs afterMethodArgs);
    }
}
