using OOPTask.Entities;

namespace OOPTask.Actions
{
    public interface IDocumentStorage
    {
        void SaveDocument(IDocument document);
        List<IDocument> SearchByDocumentNumber(string documentNumber);
    }
}

