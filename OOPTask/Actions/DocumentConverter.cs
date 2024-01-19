using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OOPTask.Entities;

namespace OOPTask.Actions
{
    public class DocumentConverter : JsonConverter<IDocument>
    {
        public override IDocument ReadJson(JsonReader reader, Type objectType, IDocument existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            string typeName = jsonObject["TypeName"].ToObject<string>();

            switch (typeName)
            {
                case nameof(Patent):
                    return jsonObject.ToObject<Patent>();
                case nameof(Book):
                    return jsonObject.ToObject<Book>();
                case nameof(LocalizedBook):
                    return jsonObject.ToObject<LocalizedBook>();
                case nameof(Magazine):
                    return jsonObject.ToObject<Magazine>();
                default:
                    throw new InvalidOperationException($"Unexpected document type: {typeName}");
            }
        }

        public override void WriteJson(JsonWriter writer, IDocument value, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.FromObject(value);
            jsonObject.Add("TypeName", value.GetType().Name);
            jsonObject.WriteTo(writer);
        }
    }
}

