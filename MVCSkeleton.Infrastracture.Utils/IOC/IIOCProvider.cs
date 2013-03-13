namespace MVCSkeleton.Infrastracture.Utils.IOC
{
    public interface IIOCProvider
    {
        T Get<T>();
    }
}