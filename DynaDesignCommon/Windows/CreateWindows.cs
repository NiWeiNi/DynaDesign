using System.Collections.Generic;
using System.Windows.Controls;
using Windows;

namespace DynaDesign
{
    public class Windows
    {
        private Windows() { }

        public static List<object> DynaDesignWindow(Grid grid, double height, double width, string title)
        {
            DynaDesignWindow window = new DynaDesignWindow(grid, height, width, title);
            window.ShowDialog();

            return window.outputSelection;
        }
    }
}
