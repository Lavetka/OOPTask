using System;
namespace OOPTask.Actions
{
    public class DocumentCacheConfig
    {
        private readonly Dictionary<Type, TimeSpan?> cacheTimes = new Dictionary<Type, TimeSpan?>();

        public void SetCacheTime(Type documentType, TimeSpan? cacheTime)
        {
            cacheTimes[documentType] = cacheTime;
        }

        public bool ShouldCache(Type documentType)
        {
            return cacheTimes.TryGetValue(documentType, out var cacheTime) && cacheTime.HasValue;
        }

        public TimeSpan GetCacheTime(Type documentType)
        {
            return cacheTimes[documentType].GetValueOrDefault();
        }
    }
}

