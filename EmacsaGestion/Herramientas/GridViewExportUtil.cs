using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 
/// </summary>
public class GridViewExportUtil
{


    public static void ExportList(string fileName, List<string> list)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";
        GridView gv=new GridView();

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a table to contain the grid
                Table table = new Table();

                //  include the gridline settings
                table.GridLines = gv.GridLines;

                GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                    // table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                foreach (GridViewRow row in gv.Rows)
                {

                    GridView gvFacturasModificacion = (GridView)row.FindControl("gvFacturasModificacion");

                    GridViewExportUtil.PrepareControlForExport(row);

                    if (gv.HeaderRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                        // table.Rows.Add(gv.HeaderRow);

                    }

                    List<TableCell> celdasB = new List<TableCell>();
                    foreach (TableCell celda in row.Cells)
                    {
                        Console.Write(celda);
                        if (celda.Text.Equals(""))
                        {
                            celdasB.Add(celda);
                        }
                    }

                    foreach (TableCell celda in celdasB)
                    {
                        row.Cells.Remove(celda);
                    }

                    table.Rows.Add(row);

                    if (gvFacturasModificacion != null)
                    {

                        List<Decimal> listToDelete = new List<Decimal>();
                        List<TableCell> celdasBorrar = new List<TableCell>();
                        if (gvFacturasModificacion.HeaderRow != null)
                        {
                            GridViewExportUtil.PrepareControlForExport(gvFacturasModificacion.HeaderRow);
                            table.Rows.Add(gvFacturasModificacion.HeaderRow);
                            Decimal idx = 0;

                            foreach (TableCell celda in gvFacturasModificacion.HeaderRow.Cells)
                            {
                                Console.Write(celda);
                                if (celda.Text.Equals("IdCliente"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }
                                if (celda.Text.Equals("NroItem"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("IdHoja"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Fecha Cobro"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Ingresada"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Estado"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Importe Modificado"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Se pagó"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                idx++;
                            }
                        }
                        foreach (TableCell celda in celdasBorrar)
                        {
                            gvFacturasModificacion.HeaderRow.Cells.Remove(celda);
                        }

                        celdasBorrar = new List<TableCell>();

                        foreach (GridViewRow r in gvFacturasModificacion.Rows)
                        {

                            foreach (Decimal idx in listToDelete)
                            {
                                celdasBorrar.Add(r.Cells[Int32.Parse(idx.ToString())]);
                            }

                            foreach (TableCell celda in celdasBorrar)
                            {
                                r.Cells.Remove(celda);
                            }

                            table.Rows.Add(r);
                        }

                        if (gvFacturasModificacion.FooterRow != null)
                        {
                            GridViewExportUtil.PrepareControlForExport(gvFacturasModificacion.FooterRow);
                            table.Rows.Add(gvFacturasModificacion.FooterRow);
                        }

                        table.Rows.Add(new TableRow());

                    }


                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <param name="gv"></param>
    public static void Export(string fileName, GridView gv)
    {
        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader(
            "content-disposition", string.Format("attachment; filename={0}", fileName));
        HttpContext.Current.Response.ContentType = "application/ms-excel";

        using (StringWriter sw = new StringWriter())
        {
            using (HtmlTextWriter htw = new HtmlTextWriter(sw))
            {
                //  Create a table to contain the grid
                Table table = new Table();

                //  include the gridline settings
                table.GridLines = gv.GridLines;

                //foreach (TableCell celda in gv.HeaderRow.Cells)
                for (int i = 0 ; i< gv.HeaderRow.Cells.Count; i++)
                {
                    TableCell celda = gv.HeaderRow.Cells[i];

                    if (celda.Text.Equals("Cliente"))
                    {
                        gv.HeaderRow.Cells.Remove(celda);
                    }

                    if (celda.Text.Equals("IdCli"))
                    {
                        gv.HeaderRow.Cells.Remove(celda);
                    }
                    if (celda.Text.Equals("Id. Deudor"))
                    {
                        gv.HeaderRow.Cells.Remove(celda);
                    }
                    if (celda.Text.Equals("NroItem"))
                    {
                        gv.HeaderRow.Cells.Remove(celda);
                    }

                }

                GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                //  add the header row to the table
                if (gv.HeaderRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                   // table.Rows.Add(gv.HeaderRow);
                }

                //  add each of the data rows to the table
                string nombreCliente = null;
                string nombreDeudor = null;
                foreach (GridViewRow row in gv.Rows)
                {
                    if (nombreCliente == null || nombreCliente != row.Cells[2].Text)
                    {
                        //nombreCliente = row.Cells[2].Text;
                        nombreDeudor = row.Cells[5].Text;
                        TableRow nuevaTR = new TableRow();
                        TableCell nuevaTD = new TableCell();
                        nuevaTD.Text = nombreDeudor;
                        nuevaTR.Cells.Add(nuevaTD);
                        table.Rows.Add(nuevaTR);

                    }

 
                    //                SetLastValues(lastValues, row, FieldNames);

         
                    row.Cells.Remove(row.Cells[1]);
                    
                    row.Cells.Remove(row.Cells[2]);

                    GridView gvFacturasModificacion = (GridView)row.FindControl("gvFacturasModificacion");

                    GridViewExportUtil.PrepareControlForExport(row);

                    if (gv.HeaderRow != null)
                    {
                        GridViewExportUtil.PrepareControlForExport(gv.HeaderRow);
                       // table.Rows.Add(gv.HeaderRow);

                    }
                    
                   // row.Cells.Remove(row.Cells[0]);
                    row.Cells.Remove(row.Cells[1]);
                    row.Cells.Remove(row.Cells[2]);
                    //row.Cells.Remove(row.Cells[4]);
                    List<TableCell> celdasB = new List<TableCell>();
                    int col = 0;
                    foreach (TableCell celda in row.Cells)
                    {
                        System.Diagnostics.Debug.Write(celda.Text);
                        if (col == 14 && row.Cells[col].Text != null && row.Cells[col].Text.Trim().Length > 0)
                        {
                            try
                            {
                                Int32.Parse(row.Cells[col].Text);
                                System.Diagnostics.Debug.Write(row.Cells[col].Text);
                                // Si es nro y no observacion, la eliminamos
                                row.Cells[col].Text = "";
                                //celdasB.Add(row.Cells[col]);
                            }
                            catch (Exception e) { 
                                
                            }
                        }
                        if (celda.Text.Equals("") || celda.Text.Trim().Equals("&nbsp;"))
                        {
                            celdasB.Add(celda);
                        }
                        col++;
                    }

                    foreach (TableCell celda in celdasB)
                    {
                        row.Cells.Remove(celda);
                    }
                    

                    table.Rows.Add(row);

                    if (gvFacturasModificacion != null) {

                        List<Decimal> listToDelete = new List<Decimal>();
                        List<TableCell> celdasBorrar = new List<TableCell>();
                        if (gvFacturasModificacion.HeaderRow != null)
                        {
                            GridViewExportUtil.PrepareControlForExport(gvFacturasModificacion.HeaderRow);
                            table.Rows.Add(gvFacturasModificacion.HeaderRow);
                            Decimal idx = 0;
                            
                            foreach (TableCell celda in gvFacturasModificacion.HeaderRow.Cells)
                            {
                                if (celda.Text.Equals("IdDeudor"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }
                                if (celda.Text.Equals("IdCliente"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }
                                if (celda.Text.Equals("NroItem"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }
                                if (celda.Text.Equals("Id. Deudor"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }
                                if (celda.Text.Equals("IdHoja"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Fecha Cobro"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Ingresada"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Estado"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Importe Modificado"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                if (celda.Text.Equals("Se pagó"))
                                {
                                    celdasBorrar.Add(celda);
                                    listToDelete.Add(idx);
                                }

                                idx++;
                            }
                        }
                        foreach (TableCell celda in celdasBorrar) {
                            gvFacturasModificacion.HeaderRow.Cells.Remove(celda);
                        }

                        celdasBorrar = new List<TableCell>();

                       foreach (GridViewRow r in gvFacturasModificacion.Rows) {

                            foreach (Decimal idx in listToDelete)
                            {
                                celdasBorrar.Add(r.Cells[Int32.Parse(idx.ToString())]);
                            }

                            foreach (TableCell celda in celdasBorrar)
                            {
                                r.Cells.Remove(celda);
                            }

                            table.Rows.Add(r);
                        }

                        if (gvFacturasModificacion.FooterRow != null)
                        {
                            GridViewExportUtil.PrepareControlForExport(gvFacturasModificacion.FooterRow);
                            table.Rows.Add(gvFacturasModificacion.FooterRow);
                        }

                       // table.Rows.Add(new TableRow());
                        
                    }

                    
                }

                //  add the footer row to the table
                if (gv.FooterRow != null)
                {
                    GridViewExportUtil.PrepareControlForExport(gv.FooterRow);
                    table.Rows.Add(gv.FooterRow);
                }

                //  render the table into the htmlwriter
                table.RenderControl(htw);

                //  render the htmlwriter into the response
                HttpContext.Current.Response.Write(sw.ToString());
                HttpContext.Current.Response.End();
            }
        }
    }

    /// <summary>
    /// Replace any of the contained controls with literals
    /// </summary>
    /// <param name="control"></param>
    private static void PrepareControlForExport(Control control)
    {
        for (int i = 0; i < control.Controls.Count; i++)
        {
            Control current = control.Controls[i];
            if (current is LinkButton)
            {
                control.Controls.Remove(current);
                //control.Controls.AddAt(i, new LiteralControl((current as LinkButton).Text));
            }
            else if (current is ImageButton)
            {
                control.Controls.Remove(current);
                //control.Controls.AddAt(i, new LiteralControl((current as ImageButton).AlternateText));
            }
            else if (current is HyperLink)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as HyperLink).Text));
            }
            else if (current is DropDownList)
            {
                control.Controls.Remove(current);
               // control.Controls.AddAt(i, new LiteralControl((current as DropDownList).SelectedItem.Text));
            }
            else if (current is CheckBox)
            {
                control.Controls.Remove(current);
               // control.Controls.AddAt(i, new LiteralControl((current as CheckBox).Checked ? "True" : "False"));
            }
            else if (current is TextBox)
            {
                control.Controls.Remove(current);
                control.Controls.AddAt(i, new LiteralControl((current as TextBox).Text));
            }
            else if (current is GridView)
            {
                control.Controls.Remove(current);
            }
            else if (current is System.Web.UI.WebControls.Image )
            {
                control.Controls.Remove(current);
                Console.Write("");
            }
            else
            {
                Console.Write("");
            }
            

            if (current.HasControls())
            {
                GridViewExportUtil.PrepareControlForExport(current);
            }
        }
    }
}

