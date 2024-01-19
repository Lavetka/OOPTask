using OOPTask.Actions;
using OOPTask.Entities;

class Program
{
    static void Main()
    {
        FileCabinet fileCabinet = new FileCabinet();

        Patent patent = new Patent { Number = "P001", Title = "Patent 1", Authors = "Author 1", DatePublished = DateTime.Now, ExpirationDate = DateTime.Now.AddYears(10), UniqueId = "U001" };
        fileCabinet.SaveDocumentCard(patent);

        Book book = new Book { Number = "B001", ISBN = "ISBN001", Title = "Book 1", Authors = "Author 2", NumberOfPages = 200, Publisher = "Publisher 1", DatePublished = DateTime.Now };
        fileCabinet.SaveDocumentCard(book);

        LocalizedBook localizedBook = new LocalizedBook { Number = "LB001", ISBN = "ISBN002", Title = "Localized Book 1", Authors = "Author 3", NumberOfPages = 250, Publisher = "Publisher 2", DatePublished = DateTime.Now, OriginalPublisher = "Original Publisher", CountryOfLocalization = "Country", LocalPublisher = "Local Publisher" };
        fileCabinet.SaveDocumentCard(localizedBook);


        Console.WriteLine("What are we looking?");
        List<IDocument> searchResults = fileCabinet.SearchByDocumentNumber(Console.ReadLine());

        Console.WriteLine("Search Results:");
        foreach (IDocument result in searchResults)
        {
            Console.WriteLine($"{result.GetType().Name} - {result.Number}");
            foreach (var property in result.GetType().GetProperties())
            {
                Console.WriteLine($"{property.Name}: {property.GetValue(result)}");
            }
        }
    }
}