using System;
using OOPTask.Actions.Interfaces;
using OOPTask.Entities;

namespace OOPTask.Actions
{
    public class DocumentCache : IDocumentCache
    {
        private readonly Dictionary<string, DocumentCacheInfo> documentCache = new Dictionary<string, DocumentCacheInfo>();

        public IDocument GetDocumentFromCache(string documentNumber)
        {
            if (documentCache.TryGetValue(documentNumber, out var cacheInfo))
            {
                return cacheInfo.Document;
            }

            return null;
        }

        public void AddDocumentToCache(IDocument document, TimeSpan cacheTime)
        {
            documentCache[document.Number] = new DocumentCacheInfo { Document = document, CacheTimestamp = DateTime.Now, CacheTime = cacheTime };
        }
    }
}

