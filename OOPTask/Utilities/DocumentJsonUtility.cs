using System;
using Newtonsoft.Json;
using OOPTask.Entities;

namespace OOPTask.Actions.Utilities
{
    public static class DocumentJsonUtility
    {
        public static string Serialize(IDocument document)
        {
            return JsonConvert.SerializeObject(document, Formatting.Indented, new DocumentConverter());
        }

        public static IDocument Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<IDocument>(json, new DocumentConverter());
        }
    }
}

