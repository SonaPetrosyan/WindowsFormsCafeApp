using System;
using System.Data;

public class ReplaceFields
{
    public static void Replace(DataTable dataTable, string f1, string f2)
    {
        // Check if the DataTable is not null and contains columns
        if (dataTable != null && dataTable.Columns.Count > 0)
        {
            // Check if the specified columns (f1 and f2) exist in the DataTable
            if (dataTable.Columns.Contains(f1) && dataTable.Columns.Contains(f2))
            {
                // Iterate through each row and replace the content of "f1" with the content of "f2"
                foreach (DataRow row in dataTable.Rows)
                {
                    row[f1] = row[f2];
                }
            }

        }
    }
}

