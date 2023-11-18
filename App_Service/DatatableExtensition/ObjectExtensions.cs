using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App_Service.DatatableExtensition
{
    public static class ObjectExtensions
    {
        public static DataTable ModelObjectToDataTable<T>(this T obj)
        {
            DataTable dataTable = new DataTable();
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            DataRow row = dataTable.NewRow();

            foreach (var property in properties)
            {
                row[property.Name] = property.GetValue(obj) ?? DBNull.Value;
            }

            dataTable.Rows.Add(row);

            return dataTable;
        }

    }
}
