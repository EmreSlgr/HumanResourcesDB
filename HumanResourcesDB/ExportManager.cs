using System;
using System.Data;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using GemBox.Document;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Fonts;  // FontResolver için

namespace HumanResourcesDB
{
    public enum ExportFormat
    {
        Excel,
        PDF,
        Word
    }
    public static class ExportManager
    {
        public static void Export(DataTable data, ExportFormat format, string filePath)
        {
            switch (format)
            {
                case ExportFormat.Excel:
                    ExportToExcel(data, filePath);
                    break;
                case ExportFormat.PDF:
                    ExportToPDF(data, filePath);
                    break;
                case ExportFormat.Word:
                    ExportToWord(data, filePath);
                    break;
                default:
                    throw new NotSupportedException($"Export format {format} desteklenmiyor.");
            }
        }

        private static void ExportToExcel(DataTable dt, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Performans");
                ws.Cell(1, 1).InsertTable(dt);
                workbook.SaveAs(filePath);
            }
        }

        private static void ExportToPDF(DataTable dt, string filePath)
        {
            GlobalFontSettings.FontResolver = new CustomFontResolver();

            var document = new PdfDocument();
            document.Info.Title = "Performans Kayıtları";

            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var font = new XFont("LiberationSans", 10, 0);

            int y = 40;
            foreach (DataRow row in dt.Rows)
            {
                string line = string.Join(", ", row.ItemArray.Select(x => x.ToString()));

                // CS0618 uyarısı giderildi:
                gfx.DrawString(line, font, XBrushes.Black,
                    new XPoint(XUnit.FromPoint(40).Point, XUnit.FromPoint(y).Point));

                y += 20;

                if (y > page.Height.Point - 40)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    y = 40;
                }
            }

            document.Save(filePath);
        }


        private static void ExportToWord(DataTable dt, string filePath)
        {
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            var document = new DocumentModel();

            var section = new Section(document);
            document.Sections.Add(section);

            var table = new GemBox.Document.Tables.Table(document);

            // Başlık satırı
            var headerRow = new GemBox.Document.Tables.TableRow(document);
            foreach (DataColumn column in dt.Columns)
                headerRow.Cells.Add(new GemBox.Document.Tables.TableCell(document, new Paragraph(document, column.ColumnName)));
            table.Rows.Add(headerRow);

            // Veri satırları
            foreach (DataRow row in dt.Rows)
            {
                var dataRow = new GemBox.Document.Tables.TableRow(document);
                foreach (var item in row.ItemArray)
                    dataRow.Cells.Add(new GemBox.Document.Tables.TableCell(document, new Paragraph(document, item.ToString())));
                table.Rows.Add(dataRow);
            }

            section.Blocks.Add(table);
            document.Save(filePath);
        }
    }

    // Basit CustomFontResolver örneği:
    public class CustomFontResolver : IFontResolver
    {
        // Font dosya adlarını kaynaklar ile eşle
        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "LiberationSans":
                    // Assembly kaynaklarından fontu oku
                    return LoadFontFromResource("HumanResourcesDB.Fonts.LiberationSans-Regular.ttf");
                default:
                    throw new ArgumentException($"Font '{faceName}' bulunamadı.");
            }
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            // Burada sadece tek font örneği var, ihtiyaç halinde çoğaltılabilir
            if (familyName.Equals("LiberationSans", StringComparison.InvariantCultureIgnoreCase))
            {
                return new FontResolverInfo("LiberationSans");
            }
            return null;
        }

        private byte[] LoadFontFromResource(string resourceName)
        {
            var asm = typeof(CustomFontResolver).Assembly;
            using (var stream = asm.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                    throw new Exception($"Font kaynağı bulunamadı: {resourceName}");
                byte[] fontData = new byte[stream.Length];
                stream.Read(fontData, 0, fontData.Length);
                return fontData;
            }
        }
    }
}
