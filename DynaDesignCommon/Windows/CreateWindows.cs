using System.Windows.Controls;
using Windows;

namespace DynaDesign
{
    public class Windows
    {
        private Windows() { }

        public static void DynaDesignWindow(Grid grid)
        {
            DynaDesignWindow window = new DynaDesignWindow(grid);
            window.ShowDialog();
        }
    }
}
