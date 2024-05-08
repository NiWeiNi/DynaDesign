using Windows;

namespace DynaDesign
{
    public class Windows
    {
        private Windows() { }

        public static void DynaDesignWindow()
        {
            DynaDesignWindow window = new DynaDesignWindow();
            window.ShowDialog();
        }
    }
}
