using System;
using OOPTask.Entities;

namespace OOPTask.Actions.Interfaces
{
	public interface IDocumentCache
	{
        IDocument GetDocumentFromCache(string documentNumber);
        void AddDocumentToCache(IDocument document, TimeSpan cacheTime);
    }
}

