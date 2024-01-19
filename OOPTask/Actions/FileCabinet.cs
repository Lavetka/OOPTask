using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOPTask.Actions.Utilities;
using OOPTask.Entities;

namespace OOPTask.Actions
{
    public class FileRepositoryStorage : IDocumentStorage
    {
        private const string LocalDirectory = "FileCabinet";

        public void SaveDocument(IDocument document)
        {
            string filePath = Path.Combine(LocalDirectory, $"{document.GetType().Name}_{document.Number}.json");
            string json = DocumentJsonUtility.Serialize(document);
            File.WriteAllText(filePath, json);
        }

        public List<IDocument> SearchByDocumentNumber(string documentNumber)
        {
            try
            {
                List<IDocument> results = new List<IDocument>();

                foreach (string filePath in Directory.GetFiles(LocalDirectory, "*.json"))
                {
                    string json = File.ReadAllText(filePath);
                    IDocument document = DocumentJsonUtility.Deserialize(json);

                    if (document.Number == documentNumber)
                    {
                        results.Add(document);
                    }
                }
                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving document: {ex.Message}");
                throw;
            }

        }
    }
}

