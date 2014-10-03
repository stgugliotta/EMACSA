// A library to handle excel files in a simple way.
// Copyright (C) 2009  Gorka Suárez García
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
//
// You should have received a copy of the GNU Lesser General Public License
// along with this program.  If not, see .
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Excel = Microsoft.Office.Interop.Excel;

namespace Herramientas
{

    /// <summary>
    /// This class is used to handle an excel file to write and read from it.
    /// Author: Gorka Suárez García
    /// </summary>
    public class ExcelHandler
    {
        /// <summary>
        /// The excel application instance.
        /// </summary>
        private ApplicationClass app;

        /// <summary>
        /// The excel book.
        /// </summary>
        private Workbook book;

        /// <summary>
        /// The path of the excel file.
        /// </summary>
        private string path;

        /// <summary>
        /// Constructs a new ExcelHandler object.
        /// </summary>
        public ExcelHandler()
        {
            this.app = null;
            this.book = null;
            this.path = null;
        }

        /// <summary>
        /// Destroys the ExcelHandler object.
        /// </summary>
        ~ExcelHandler()
        {
            if (this.app != null)
            {
                this.app.Quit();
            }
        }

        /// <summary>
        /// Opens an excel file.
        /// </summary>
        /// <param name="path">The file to open.</param>
        public void Open(string path)
        {
            this.path = path;

            this.app = new ApplicationClass();
            this.app.Visible = false;
            this.app.ScreenUpdating = false;
            this.app.DisplayAlerts = false;

            this.book = this.app.Workbooks.Open(this.path, Missing.Value, Missing.Value, Missing.Value,
                                                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                Missing.Value, Missing.Value, Missing.Value, Missing.Value,
                                                Missing.Value, Missing.Value, Missing.Value);

            if (this.book == null)
                throw new Exception("Can't open the excel book file.");
        }

        /// <summary>
        /// Writes a value in a cell.
        /// </summary>
        /// <param name="sheet">The sheet to write.</param>
        /// <param name="cell">The cell to write.</param>
        /// <param name="value">The value to write.</param>
        public void Write(string sheet, string cell, string value)
        {
            Worksheet wsheet = this.getSheet(sheet);
            Range range = wsheet.get_Range(cell, cell);
            range.Value2 = value;
        }

        /// <summary>
        /// Reads a value from a cell.
        /// </summary>
        /// <param name="sheet">The sheet to read.</param>
        /// <param name="cell">The cell to read.</param>
        /// <returns>The value from the cell.</returns>
        public string Read(string sheet, string cell)
        {
            Worksheet wsheet = this.getSheet(sheet);
            Range range = wsheet.get_Range(cell, cell);

            if (range.Value2 != null)
                return range.Value2.ToString();
            else
                return "";
        }

        public string Read(Range range, int rCnt, int cCnt)
        {
            string strCelda = null;

            try
            {
                strCelda = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2;
            }
            catch (Exception e)
            {
                try
                {
                    strCelda = (string)(range.Cells[rCnt, cCnt] as Excel.Range).Value2.ToString();
                }
                catch (Exception ex)
                {



                    if ((range.Cells[rCnt, cCnt] as Excel.Range).NumberFormat.ToString().Contains("#"))
                    {
                        // Es un numerico..
                        strCelda = (range.Cells[rCnt, cCnt] as Excel.Range).Value2.ToString();
                    }
                    else
                    {
                        // Es una fecha
                        TimeSpan datefromexcel = new TimeSpan(Convert.ToInt32((range.Cells[rCnt, cCnt] as Excel.Range).Value2) - 2, 0, 0, 0);

                        DateTime inputdate = new DateTime(1900, 1,
                        1).Add(datefromexcel);

                        strCelda = inputdate.ToString();
                    }
                }

            }

            return strCelda;
        }
        /// <summary>
        /// Clears the content of the excel book.
        /// </summary>
        public void Clear()
        {
            Worksheet sheet = null;
            for (int i = 1; i <= this.book.Worksheets.Count; i++)
            {
                sheet = (Worksheet)this.book.Worksheets[i];
                sheet.Cells.Clear();
            }
        }

        /// <summary>
        /// Closes the excel file.
        /// </summary>
        public void Close()
        {
            this.book.SaveAs(this.path, XlFileFormat.xlWorkbookNormal, Missing.Value, Missing.Value,
                             false, false, XlSaveAsAccessMode.xlShared, false, false, Missing.Value,
                             Missing.Value, Missing.Value);
            this.book.Close(true, Missing.Value, Missing.Value);
            this.app.Quit();

            this.app = null;
            this.book = null;
            this.path = null;
        }

        /// <summary>
        /// Gets all the names of the sheets inside the excel book.
        /// </summary>
        /// <returns>A list of the sheets names.</returns>
        public string[] GetSheetsNames()
        {
            List<String> names = new List<String>();
            Worksheet sheet = null;

            for (int i = 1; i <= this.book.Worksheets.Count; i++)
            {
                sheet = (Worksheet)this.book.Worksheets[i];
                names.Add(sheet.Name);
            }

            return names.ToArray();
        }

        /// <summary>
        /// Gets a sheet we're looking for.
        /// </summary>
        /// <param name="name">The name of the sheet.</param>
        /// <returns>The sheet we're looking for.</returns>
        public Worksheet getSheet(string name)
        {
            int index = this.getSheetIndex(name);
            if (index == 0)
                throw new Exception("Invalid sheet name.");

            Worksheet sheet = (Worksheet)this.book.Worksheets[index];
            return sheet;
        }

        /// <summary>
        /// Gets the index of a sheet we're looking for.
        /// </summary>
        /// <param name="name">The name of the sheet.</param>
        /// <returns>The index of the sheet we're looking for.</returns>
        protected int getSheetIndex(string name)
        {
            Worksheet sheet = null;
            for (int i = 1; i <= this.book.Worksheets.Count; i++)
            {
                sheet = (Worksheet)this.book.Worksheets[i];
                if (sheet.Name == name) return i;
            }
            return 0;
        }
    }
}
