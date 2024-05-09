using System.Windows.Controls;
using Windows;

namespace DynaDesign
{
    public class Windows
    {
        private Windows() { }

        public static void DynaDesignWindow(Grid grid, double height, double width, string title)
        {
            DynaDesignWindow window = new DynaDesignWindow(grid, height, width, title);
            window.ShowDialog();
        }
    }
}
