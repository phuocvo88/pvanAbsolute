using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace practiceAPIOpenWeather.Utilities
{
    public class ExcelDataReader
    {
        public static IEnumerable<TestCaseData> ReadXlsxDataDriveFile(string path, string sheetName, [Optional] string testName)
        {
            XSSFWorkbook wb;

            using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                wb = new XSSFWorkbook(fs);
            }

            // get sheet
            var sh = (XSSFSheet)wb.GetSheet(sheetName);

            int startRow = 1;
            int startCol = 0;
            int totalRows = sh.LastRowNum;
            int totalCols = sh.GetRow(0).LastCellNum;

            var row = 1;
            for (int i = startRow; i <= totalRows; i++, row++)
            {
                var column = 0;
                var testParams = new Dictionary<string, string>();
                for (int j = startCol; j < totalCols; j++, column++)
                {
                    if (sh.GetRow(0).GetCell(column).CellType != CellType.String)
                    {
                        throw new InvalidOperationException(string.Format("Cell with name of parameter must be string only, file {0} at sheet {1} row {2} column {3}", path, sheetName, 0, column));
                    }

                    var cellType = CellType.Blank;
                    try
                    {
                        if (sh.GetRow(row) != null && sh.GetRow(row).GetCell(column) != null)
                        {
                            cellType = sh.GetRow(row).GetCell(column).CellType;
                        }
                    }
                    catch (NullReferenceException ex)
                    {
                        throw ex;
                    }
                    switch (cellType)
                    {
                        case CellType.String:
                            testParams.Add(sh.GetRow(0).GetCell(column).StringCellValue, sh.GetRow(row).GetCell(column).StringCellValue);
                            break;
                        case CellType.Numeric:
                            testParams.Add(sh.GetRow(0).GetCell(column).StringCellValue, sh.GetRow(row).GetCell(column).NumericCellValue.ToString(CultureInfo.CurrentCulture));
                            break;
                        case CellType.Blank:
                            testParams.Add(sh.GetRow(0).GetCell(column).StringCellValue, "null");
                            break;
                        default:
                            throw new InvalidOperationException(string.Format("Not supported cell type {0} in file {1} at sheet {2} row {3} column {4}", cellType, path, sheetName, row, column));
                    }
                }

                // set test name
                var testCaseName = string.IsNullOrEmpty(testName) ? sheetName : testName;
                if (!string.IsNullOrEmpty(testName) && totalRows > 1)
                {
                    testCaseName = testCaseName + "_data row(" + row + ")";
                }

                var data = new TestCaseData(testParams);
                data.SetName(testCaseName);
                yield return data;
            }

        }

    }
}
