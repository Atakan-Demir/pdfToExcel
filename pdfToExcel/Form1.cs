using System;
using System.Reflection.PortableExecutable;
using System.Text;
using System.IO;
using ClosedXML.Excel;

//using iTextSharp.text.pdf;
//using iTextSharp.text.pdf.parser;
using Spire.Doc;
using Spire.Pdf;
using Spire.Pdf.Texts;
using Spire.Pdf.Utilities;
using Spire.Xls;

namespace pdfToExcel
{
    public partial class Form1 : Form
    {

        private string userName = Environment.UserName;
        private List<string> path = new List<string>();
        private List<(string AdSoyad, string Tutar, string Komisyon)> data = new List<(string, string, string)>();

        public Form1()
        {
            InitializeComponent();
           

        }
        
        

        private void button1_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                // Kullan�c�ya klas�r se�me diyalogunu g�ster
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    // Se�ilen klas�r�n yolunu al
                    string selectedFolderPath = folderBrowserDialog.SelectedPath;
                    richTextBox1.Text = "Se�ilen Klas�r: " + selectedFolderPath;

                    // Se�ilen klas�rdeki t�m .pdf dosyalar�n� listele
                    string[] pdfFiles = Directory.GetFiles(selectedFolderPath, "*.pdf");
                    foreach (string file in pdfFiles)
                    {
                        richTextBox1.Text += "\n" + file;
                    }
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            ConvertPdfToExcel();
        }


        public void ConvertPdfToExcel()
        {
            GetAllPdfPath();
            pdfToExcelCustomDef();
            CreateExcelFileWithClosedXML();
        }

        private void GetAllPdfPath()
        {
            string[] pdfFiles = Directory.GetFiles(@"C:\Users\" + userName + @"\Desktop\faturalar", "*.pdf");
            foreach (string file in pdfFiles)
            {
                path.Add(file);
            }
        }

        private void pdfToExcelCustomDef()
        {
            foreach (var i in path)
            {
                PdfDocument pdf = new PdfDocument();
                pdf.LoadFromFile(i);

                PdfTableExtractor extractor = new PdfTableExtractor(pdf);
                PdfTable[] pdfTables = extractor.ExtractTable(0);

                string adsoyad = pdfTables[0].GetText(1, 0);
                string tutar = pdfTables[1].GetText(10, 7);
                string komisyon = Komisyon(tutar);

                data.Add((adsoyad, tutar, komisyon));
            }
        }

        private string Komisyon(string tutar)
        {
            if (double.TryParse(tutar, out double tutarValue))
            {
                return (tutarValue * 0.02).ToString("N2");
            }
            return "0.00";
        }

        private void CreateExcelFileWithClosedXML()
        {
            string filePath = @"C:\Users\" + userName + @"\Desktop\test.xlsx";
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Paket Taxi");

                // Ba�l�k sat�r�n� ekle
                worksheet.Cell("A1").Value = "�sim Soyisim";
                worksheet.Cell("B1").Value = "Fatura Tutar�";
                worksheet.Cell("C1").Value = "Komisyon Miktar�";

                // Veri sat�rlar�n� ekle
                int row = 2;
                foreach (var item in data)
                {
                    worksheet.Cell("A" + row).Value = item.AdSoyad;
                    worksheet.Cell("B" + row).Value = item.Tutar;
                    worksheet.Cell("C" + row).Value = item.Komisyon;
                    row++;
                }

                // Tablo olarak bi�imlendir
                var range = worksheet.Range("A1:C" + (row - 1));
                var table = range.CreateTable();

                // Dosyay� kaydet
                workbook.SaveAs(filePath);
            }
        }

    }
}