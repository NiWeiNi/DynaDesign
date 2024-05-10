using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Windows;

namespace Controls
{
    public class Buttons
    {
        private Buttons() { }

        public static Button CreateButtonOk(string text)
        {
            Button button = new Button();
            button.Content = text;
            button.Click += Button_Click;

            return button;
        }

        private static void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DynaDesignWindow window = Window.GetWindow((Button)sender) as DynaDesignWindow;

            if (window != null)
            {
                window.IsOK = true;

                List<object> list = new List<object>();

                Grid control = window.Content as Grid;
                UIElementCollection uIElementCollection = control.Children as UIElementCollection;

                foreach (var element in uIElementCollection)
                {
                    if (element is Grid)
                    {

                    }
                    else if (element is ComboBox)
                    {
                        list.Add((element as ComboBox).SelectedItem);
                    }
                }

                window.outputSelection = list;
                window.Close();
            }
        }
    }
}
