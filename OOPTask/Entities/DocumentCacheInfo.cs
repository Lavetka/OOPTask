namespace OOPTask.Entities
{
    public class DocumentCacheInfo
    {
        public IDocument Document { get; set; }
        public DateTime CacheTimestamp { get; set; }
        public TimeSpan CacheTime { get; set; }
    }
}

