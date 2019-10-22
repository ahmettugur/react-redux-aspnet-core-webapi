using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ATCommon.Utilities
{
    public class DataTableParser
    {
        public static string DataTableToJsonList(DataTable dataTable)
        {
            if (dataTable == null)
                return string.Empty;

            if (dataTable.Rows.Count == 0)
                return string.Empty;

            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row;

            foreach (DataRow dr in dataTable.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    dynamic dynamicValue = dr[col];
                    string value = dr[col].ToString();

                    if (dynamicValue.GetType() == typeof(DateTime))
                    {
                        value = Convert.ToDateTime(dynamicValue).ToShortDateString();
                    }

                    row.Add(col.ColumnName, value);
                }
                rows.Add(row);
            }
            dataTable.Dispose();

            string data = JsonConvert.SerializeObject(rows);

            return data;
        }
        public static string DataTableToJsonObject(DataTable dataTable)
        {
            if (dataTable == null)
                return string.Empty;

            if (dataTable.Rows.Count == 0)
                return string.Empty;

            Dictionary<string, object> row;
            DataRow dr = dataTable.Rows[0];

            row = new Dictionary<string, object>();
            foreach (DataColumn col in dataTable.Columns)
            {
                dynamic dynamicValue = dr[col];
                string value = dr[col].ToString();

                if (dynamicValue.GetType() == typeof(DateTime))
                {
                    value = Convert.ToDateTime(dynamicValue).ToShortDateString();
                }

                row.Add(col.ColumnName, value);
            }
            dataTable.Dispose();

            string data = JsonConvert.SerializeObject(row);

            return data;
        }
        public static string DataTableToHTML(DataTable dataTable)
        {
            string html = "<table>";
            //add header row
            html += "<thead><tr>";
            for (int i = 0; i < dataTable.Columns.Count; i++)
                html += "<td>" + dataTable.Columns[i].ColumnName + "</td>";
            html += "</tr></thead>";
            //add rows
            html += "<tbody>";
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                html += "<tr>";
                for (int j = 0; j < dataTable.Columns.Count; j++)
                    html += "<td>" + dataTable.Rows[i][j].ToString() + "</td>";
                html += "</tr>";
            }
            html += "</thead></table>";
            return html;
        }
    }
}
