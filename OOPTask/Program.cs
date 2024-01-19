using OOPTask.Actions;
using OOPTask.Actions.Interfaces;
using OOPTask.Entities;

class Program
{
    static void Main()
    {
        IDocumentStorage documentStorage = new FileRepositoryStorage();

        IDocumentCache documentCache = new DocumentCache();
        var cacheConfig = new DocumentCacheConfig();
        cacheConfig.SetCacheTime(typeof(Patent), TimeSpan.FromDays(1));
        IDocumentStorage storageWithCache = new DocumentStorageWithCache(documentStorage, documentCache, cacheConfig);


        Patent patent = new Patent { Number = "P001", Title = "Patent 1", Authors = "Author 1", DatePublished = DateTime.Now, ExpirationDate = DateTime.Now.AddYears(10), UniqueId = "U001" };
        documentStorage.SaveDocument(patent);

        Book book = new Book { Number = "B001", ISBN = "ISBN001", Title = "Book 1", Authors = "Author 2", NumberOfPages = 200, Publisher = "Publisher 1", DatePublished = DateTime.Now };
        documentStorage.SaveDocument(book);

        LocalizedBook localizedBook = new LocalizedBook { Number = "LB001", ISBN = "ISBN002", Title = "Localized Book 1", Authors = "Author 3", NumberOfPages = 250, Publisher = "Publisher 2", DatePublished = DateTime.Now, OriginalPublisher = "Original Publisher", CountryOfLocalization = "Country", LocalPublisher = "Local Publisher" };
        documentStorage.SaveDocument(localizedBook);

        Magazine magazine = new Magazine { Number = "M001", Title = "Magazine 1", Publisher = "Publisher X", ReleaseNumber = 1, PublishDate = DateTime.Now };
        documentStorage.SaveDocument(magazine);


        Console.WriteLine("What are we looking?");
        List<IDocument> searchResults = storageWithCache.SearchByDocumentNumber(Console.ReadLine());

        Console.WriteLine("Search Results:");
        foreach (IDocument result in searchResults)
        {
            Console.WriteLine($"{result.GetType().Name} - {result.Number}");
            foreach (var property in result.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(result)}");
            }
        }

        Console.WriteLine("What are we looking?");
        List<IDocument> searchResultss = storageWithCache.SearchByDocumentNumber(Console.ReadLine());

        Console.WriteLine("Search Results:");
        foreach (IDocument result in searchResultss)
        {
            Console.WriteLine($"{result.GetType().Name} - {result.Number}");
            foreach (var property in result.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(result)}");
            }
        }
    }
}