using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Controls
{
    public class Layout
    {
        private Layout() { }

        public static Border CreateBorder(Control content, double padding)
        {
            Border border = new Border();
            border.Padding = new Thickness(padding);
            border.Child = content;

            return border;
        }

        public static Grid CreateGrid(List<object> content, List<double> columnDefinitions, List<double> rowDefinitions,
            List<int> elementColumn, List<int> elementRow)
        {
            Grid grid = new Grid();

            foreach (double columnDefinition in columnDefinitions)
            {
                ColumnDefinition column = new ColumnDefinition
                {
                    Width = new GridLength(columnDefinition, GridUnitType.Star)
                };

                grid.ColumnDefinitions.Add(column);
            }

            foreach (double rowDefinition in rowDefinitions)
            {
                RowDefinition column = new RowDefinition
                {
                    Height = new GridLength(rowDefinition, GridUnitType.Star)
                };

                grid.RowDefinitions.Add(column);
            }

            for (int i = 0; i < content.Count; i++)
            {
                Control control = content[i] as Control;

                if (!grid.Children.Contains(control) && content[i] != null)
                {
                    RemoveControlFromParent(control);

                    int rowIndex;
                    if (i < elementRow.Count)
                        rowIndex = elementRow[i];
                    else
                        rowIndex = elementRow.Last();
                    int columnIndex;
                    if (i < elementColumn.Count)
                        columnIndex = elementColumn[i];
                    else
                        columnIndex = elementColumn.Last();

                    Grid.SetRow(control, rowIndex);
                    Grid.SetColumn(control, columnIndex);
                    grid.Children.Add(control);
                }
            }

            return grid;
        }

        private static void RemoveControlFromParent(Control control)
        {
            object currentParent = VisualTreeHelper.GetParent(control);

            if (currentParent != null)
            {
                Grid grid = currentParent as Grid;
                if (currentParent != null)
                {
                    if (VisualTreeHelper.GetParent(control) is Panel parent)
                    {
                        parent.Children.Remove(control);
                    }
                }
            }
        }
    }
}