using System;
using System.Reflection.PortableExecutable;
using System.Text;
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

        string userName = Environment.UserName;
        List<string> path = new List<string>();
        public Form1()
        {
            InitializeComponent();
            //path = @"C:\Users\" + userName + @"\Desktop\fatura.pdf";
            GetAllPdfPath();

        }

        public void GetAllPdfPath()
        {

            string[] pdfFiles = Directory.GetFiles(@"C:\Users\" + userName + @"\Desktop\faturalar", "*.pdf");

            foreach (string file in pdfFiles)
            {
                path.Add(file);
            }
            foreach (var i in path)
            {
                richTextBox1.Text += i + "\n";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //pdfToExcelDef();
        }
        /*
        public void pdfToExcelDef()
        {
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(path);
            //document.SaveToFile("PDFToExcel.xlsx", FileFormat.XLSX);
        }
        */
        private void button2_Click(object sender, EventArgs e)
        {
            //pdfToExcelTableDef();
        }
        /*
        public void pdfToExcelTableDef()
        {

            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(path);

            PdfTableExtractor extractor = new PdfTableExtractor(pdf);

            PdfTable[] pdfTables = extractor.ExtractTable(0);

            Workbook wb = new Workbook();

            wb.Worksheets.Clear();

            if (pdfTables != null && pdfTables.Length > 0)
            {

                for (int tableNum = 0; tableNum < pdfTables.Length; tableNum++)
                {

                    String sheetName = String.Format("Table - {0}", tableNum + 1);
                    Worksheet sheet = wb.Worksheets.Add(sheetName);

                    for (int rowNum = 0; rowNum < pdfTables[tableNum].GetRowCount(); rowNum++)
                    {

                        for (int colNum = 0; colNum < pdfTables[tableNum].GetColumnCount(); colNum++)
                        {

                            String text = pdfTables[tableNum].GetText(rowNum, colNum);

                            sheet.Range[rowNum + 1, colNum + 1].Text = text;
                        }
                    }

                    sheet.AllocatedRange.AutoFitColumns();
                }
            }

            wb.SaveToFile("ExportTableToExcel.xlsx", ExcelVersion.Version2016);


        }
        */

        public void pdfToExcelCustomDef()
        {


            string adsoyad;
            string tutar;
            string komisyon;
            string satir;
           
            foreach (var i in path)
            {
                PdfDocument pdf = new PdfDocument();
                pdf.LoadFromFile(i);

                PdfTableExtractor extractor = new PdfTableExtractor(pdf);

                PdfTable[] pdfTables = extractor.ExtractTable(0);

                //Workbook wb = new Workbook();

                //wb.Worksheets.Clear();

                adsoyad = pdfTables[0].GetText(1, 0);

                tutar = pdfTables[1].GetText(10, 7);

                /*
                textBox1.Text = adsoyad;
                textBox2.Text = tutar;
                */
                komisyon = Komisyon(tutar);

                //textBox3.Text = komisyon;

                satir = "Ad Soyad : " + adsoyad + " | " + " Toplam Fatura Tutarý: " + tutar + " | " + " Komisyon Miktarý: " + komisyon;

                richTextBox1.Text += satir + "\n";
                //clear strings

            }




            /*
            pdf.LoadFromFile(path);

            PdfTableExtractor extractor = new PdfTableExtractor(pdf);

            PdfTable[] pdfTables = extractor.ExtractTable(0);

            Workbook wb = new Workbook();

            wb.Worksheets.Clear();

            String adsoyad = pdfTables[0].GetText(1, 0);

            String tutar = pdfTables[1].GetText(10, 7);


            textBox1.Text = adsoyad;
            textBox2.Text = tutar;

            string komisyon = Komisyon(Convert.ToDouble(tutar)).ToString();

            textBox3.Text = komisyon;
            */

        }

    public string Komisyon(string x)
    {
            string result;
            if (double.TryParse(x, out double y))
            {
                // Dönüþüm baþarýlý, 'result' deðiþkeni dönüþtürülmüþ deðeri içerir.
                result = (y * 0.02).ToString();
                return result;
            }
            else
            {
                // Dönüþüm baþarýsýz, uygun bir hata mesajý göster veya iþlemi durdur.
                result = "Dönüþüm baþarýsýz";
                return result;
            }

           
    }


    private void button3_Click(object sender, EventArgs e)
    {
        pdfToExcelCustomDef();
        /*
        var deger = ExtractTextFromPdf(path);
        richTextBox1.Text = deger;
        */
    }

    /*
    public string ExtractTextFromPdf(string path)
    {
        using (PdfReader reader = new PdfReader(path))
        {
            StringBuilder text = new StringBuilder();
            textBox1.Text = reader.NumberOfPages.ToString();
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                text.Append(iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, 1));
            }

            return text.ToString();
        }
    }
    */
}

}