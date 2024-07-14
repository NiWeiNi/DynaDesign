using System.Collections.Generic;
using System.Windows.Controls;

namespace Controls
{
    public class DataDisplay
    {
        private DataDisplay() { }

        public static DataGrid CreateDatGrid(List<DataGridColumn> columns, List<object> objects)
        {
            DataGrid dataGrid = new DataGrid
            {
                AutoGenerateColumns = false,
                ItemsSource = objects
            };

            foreach (DataGridColumn item in columns)
            {
                dataGrid.Columns.Add(item);
            }

            return dataGrid;
        }

        public static DataGridColumn CreateDataGridColumn(string headerTitle, string propertyName)
        {
            DataGridTextColumn textColumn = new DataGridTextColumn
            {
                Header = headerTitle,
                Binding = new System.Windows.Data.Binding(propertyName)
            };

            return textColumn;
        }
    }
}
