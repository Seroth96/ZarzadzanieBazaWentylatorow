using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace ZarzadzanieBaza.Helpers
{
    class ExcellReader
    {
        public List<double> Q { get; set; } = new List<double>();
        public List<double> Dp { get; set; } = new List<double>();
        public void getExcelFile(string filename)
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filename);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            int Qcolstart = -1;
            int Qrowstart = -1;
            int DpColstart= -1;
            int Dprowstart = -1;
            //iterate over the rows and columns and finding the right columns
            for (int i = 1; i <= rowCount; i++)
            {
                if (Qrowstart != -1)
                {
                    var Qcell = xlRange.Cells[i, Qcolstart].Value2.ToString();
                    var Dpcell = xlRange.Cells[i, DpColstart].Value2.ToString();
                    if (Qcell == "0" || Dpcell == "0")
                    {
                        break;
                    } 
                    Q.Add(double.Parse(Qcell));
                    Dp.Add(double.Parse(Dpcell));
                }
                else
                {
                    for (int j = 1; j <= colCount; j++)
                    {
                        //write the value to the console
                        if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        {
                            var content = xlRange.Cells[i, j].Value2.ToString();
                            if (content == "Q(m3/s)") //change to regular expression later
                            {
                                Qrowstart = i;
                                Qcolstart = j;
                                DpColstart = j + 1;
                                Dprowstart = i;
                            }
                            if (Qrowstart != -1)
                            {
                                break;
                            }
                        }
                        //Console.Write( + "\t");
                    }
                }


            }

            //cleanup

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            

            //close and release
            xlWorkbook.Close(false, Type.Missing, Type.Missing);

            //quit and release
            xlApp.Workbooks.Close();
            xlApp.Quit(); Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
}
