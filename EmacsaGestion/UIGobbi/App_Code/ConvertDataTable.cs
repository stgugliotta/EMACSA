using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Clase genérica para convertir una Lista Genérica de elementos en un objeto DataTable
/// </summary>
/// <typeparam name="TDataContract">Tipo de datos de los elementos de la Lista.Debe ser una clase con un constructor sin parámetros.</typeparam>
public static class ConvertDataTable<TDataContract> where TDataContract : new()
{
    public static DataTable Convert(List<TDataContract> listaDataContract)
    {
        DataTable dataTable = new DataTable();
        Type itemsType = typeof(TDataContract);

        foreach (PropertyInfo property in itemsType.GetProperties())
        {
            DataColumn column = new DataColumn(property.Name);
            column.DataType = property.PropertyType;
            dataTable.Columns.Add(column);
          
        }

        foreach (TDataContract dataContract in listaDataContract)
        {
            DataRow row = dataTable.NewRow();

            foreach (PropertyInfo property in itemsType.GetProperties())
            {
                row[property.Name] = property.GetValue(dataContract, null);
            }

            dataTable.Rows.Add(row);
        }
        return dataTable;
    }

    public static List<TDataContract> Convert(DataTable dataTable)
    {
        Type itemsType = typeof(TDataContract);
        object value;
        List<TDataContract> list = new List<TDataContract>();

        foreach (DataRow row in dataTable.Rows)
        {
            TDataContract DataContract = new TDataContract();
            
            foreach (PropertyInfo property in itemsType.GetProperties())
            {
                value = row[property.Name];
                if (value != System.DBNull.Value)
                {
                    property.SetValue(DataContract, value, null);
                }
            }

            list.Add(DataContract);
        }

        return list;
    }
}
