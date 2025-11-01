using System;

namespace UPT.DocumentConverters
{
    public interface IDocumentConverter
    {
        string Convert(string content);
        string TargetExtension { get; }
    }

    // Concrete Implementations for the Products
    public class DocxConverter : IDocumentConverter
    {
        public string Convert(string content)
        {
            string conversion = " [Converted to DOCX]";
            return content + conversion;
        }

        public string TargetExtension => ".docx";
    }

    public class PdfConverter : IDocumentConverter
    {
        public string Convert(string content)
        {
            string conversion = " [Converted to PDF]";
            return content + conversion;
        }

        public string TargetExtension => ".pdf";
    }

    public class TxtConverter : IDocumentConverter
    {
        public string Convert(string content)
        {
            string conversion = " [Converted to TXT]";
            return content + conversion;
        }

        public string TargetExtension => ".txt";
    }

    public static class DocumentConverterFactory
    {
        public static IDocumentConverter CreateDocumentConverter(string format)
        {
            if (format == null) throw new ArgumentNullException(nameof(format));
            switch (format.ToLowerInvariant())
            {
                case "docx":
                    return new DocxConverter();
                case "pdf":
                    return new PdfConverter();
                case "txt":
                    return new TxtConverter();
                default:
                    throw new ArgumentException($"Unsupported document format: {format}", nameof(format));
            }
        }
    }
}