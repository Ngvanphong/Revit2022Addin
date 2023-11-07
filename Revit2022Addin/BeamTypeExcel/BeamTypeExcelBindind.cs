using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Win32;
using OfficeOpenXml;
using Revit2022Addin.BeamTypeExcel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Revit2022Addin.BeamTypeExcel
{
    [Transaction(TransactionMode.Manual)]
    public class BeamTypeExcelBindind : IExternalCommand

    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            var formDialog = new  System.Windows.Forms.OpenFileDialog();
            formDialog.Filter = "xlsx files (*.xlsx)|*.xlsx";
            formDialog.ShowDialog();
            string fille = formDialog.FileName;

            if(File.Exists(fille))
            {
                FileInfo existingFile = new FileInfo(fille);
                ExcelPackage.LicenseContext = LicenseContext.Commercial;
                using (ExcelPackage package = new ExcelPackage(existingFile))
                {
                    //get the first worksheet in the workbook
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    
                    int colCount = worksheet.Dimension.End.Column;  //get Column Count
                    int rowCount = worksheet.Dimension.End.Row;     //get row count
                    for (int row = 1; row <= rowCount; row++)
                    {
                        double b = (double)worksheet.Cells[row+1, 1].Value;
                    }
                }


            }



            return Result.Succeeded;
        }
    }
}
