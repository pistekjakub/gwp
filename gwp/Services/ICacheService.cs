namespace gwp.Services
{
    public interface ICacheService
    {
        void SetValue(string key, object value);

        T? GetValue<T>(string key);
    }
}
