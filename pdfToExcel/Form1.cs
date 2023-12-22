using System;
using Spire.Doc;
using Spire.Pdf;
using Spire.Pdf.Utilities;
using Spire.Xls;

namespace pdfToExcel
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            pdfToExcelDef();
        }

        public void pdfToExcelDef()
        {
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"C:\Users\DmR\Desktop\fatura.pdf");
            //document.SaveToFile("PDFToExcel.xlsx", FileFormat.XLSX);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pdfToExcelTableDef();
        }

        public void pdfToExcelTableDef()
        {

            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"C:\\Users\\DmR\\Desktop\\fatura.pdf");

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

        public void pdfToExcelCustomDef()
        {
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"C:\\Users\\DmR\\Desktop\\fatura.pdf");

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

        }

        public double Komisyon(double x)
        {
            double result = x * 0.02;
            return result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pdfToExcelCustomDef();
        }
    }

}