namespace Core.Contracts
{
    public interface ICacheService<T>
    {
        T? GetCache(string key);

        void SetCache(string key, T value, TimeSpan expiry);
    }
}