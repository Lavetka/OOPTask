using System;
using OOPTask.Actions.Interfaces;
using OOPTask.Entities;

namespace OOPTask.Actions
{
    public class DocumentStorageWithCache : IDocumentStorage
    {
        private readonly IDocumentStorage wrappedStorage;
        private readonly IDocumentCache documentCache;
        private readonly DocumentCacheConfig cacheConfig;

        public DocumentStorageWithCache(IDocumentStorage wrappedStorage, IDocumentCache documentCache, DocumentCacheConfig cacheConfig)
        {
            this.wrappedStorage = wrappedStorage ?? throw new ArgumentNullException(nameof(wrappedStorage));
            this.documentCache = documentCache ?? throw new ArgumentNullException(nameof(documentCache));
            this.cacheConfig = cacheConfig ?? throw new ArgumentNullException(nameof(cacheConfig));
        }

        public void SaveDocument(IDocument document)
        {
            wrappedStorage.SaveDocument(document);
        }

        public List<IDocument> SearchByDocumentNumber(string documentNumber)
        {
            IDocument cachedDocument = documentCache.GetDocumentFromCache(documentNumber);

            if (cachedDocument != null)
            {
                Console.WriteLine($"Found in cache: {cachedDocument.GetType().Name} - {cachedDocument.Number}");
                return new List<IDocument> { cachedDocument };
            }

            List<IDocument> results = wrappedStorage.SearchByDocumentNumber(documentNumber);

            foreach (var result in results)
            {
                if (cacheConfig.ShouldCache(result.GetType()))
                {
                    documentCache.AddDocumentToCache(result, cacheConfig.GetCacheTime(result.GetType()));
                    Console.WriteLine($"Added to cache: {result.GetType().Name} - {result.Number}");
                }
            }

            return results;
        }
    }
}

