using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOPTask.Entities;

namespace OOPTask.Actions
{
    public class FileCabinet
    {
        private const string FileDirectory = "FileCabinet";

        public void SaveDocumentCard(IDocument document)
        {
            string filePath = Path.Combine(FileDirectory, $"{document.GetType().Name}_{document.Number}.json");
            string json = JsonConvert.SerializeObject(document, Formatting.Indented, new DocumentConverter());
            File.WriteAllText(filePath, json);
        }

        public List<IDocument> SearchByDocumentNumber(string documentNumber)
        {
            List<IDocument> results = new List<IDocument>();

            foreach (string filePath in Directory.GetFiles(FileDirectory, "*.json"))
            {
                string json = File.ReadAllText(filePath);
                IDocument document = JsonConvert.DeserializeObject<IDocument>(json, new DocumentConverter());

                if (document.Number == documentNumber)
                {
                    results.Add(document);
                }
            }

            return results;
        }
    }
}

