using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pdf_reader
{
    public class Parser
    {
        public FileInfo File { get; private set; }

        public Parser(string fileName)
        {
            File = new FileInfo(fileName);
            if (string.IsNullOrWhiteSpace(fileName)
                || !File.Exists
                || !File.Extension.ToLowerInvariant().Equals(".pdf"))
                throw new ArgumentException("Invalid File");
        }

        public string ToText()
        {
            var pdfReader = new PdfReader(File.FullName);
            var sb = new StringBuilder();
            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                var strategy = new SimpleTextExtractionStrategy();
                string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                sb.Append(currentText);
            }
            pdfReader.Close();
            return sb.ToString();
        }

        public string ToLocationText()
        {
            var pdfReader = new PdfReader(File.FullName);
            var sb = new StringBuilder();
            for (int page = 1; page <= pdfReader.NumberOfPages; page++)
            {
                var strategy = new LocationTextExtractionStrategy();
                string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, page, strategy);

                currentText = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(currentText)));
                sb.Append(currentText);
            }
            pdfReader.Close();
            return sb.ToString();
        }

    }
}
