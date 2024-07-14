using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WindowsCreation;

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

        public static Button CreateButtonCancel(string text)
        {
            Button button = new Button();
            button.Content = text;
            button.Click += Button_Click_Cancel;

            return button;
        }

        private static void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            DynaDesignWindow window = Window.GetWindow((Button)sender) as DynaDesignWindow;

            if (window != null)
                window.Close();
        }

        private static void Button_Click(object sender, RoutedEventArgs e)
        {
            DynaDesignWindow window = Window.GetWindow((Button)sender) as DynaDesignWindow;

            if (window != null)
            {
                window.IsOK = true;
                List<object> list = new List<object>();

                TraverseVisualTree(window.Content, ref list);

                window.outputSelection = list;
                window.Close();
            }
        }

        private static void TraverseVisualTree(object treeElement, ref List<object> outList)
        {
            if (treeElement is UIElementCollection)
            {
                foreach (var element in (treeElement as UIElementCollection))
                    TraverseVisualTree(element, ref outList);
            }
            else if (treeElement is Grid)
            {
                TraverseVisualTree((treeElement as Grid).Children, ref outList);
            }
            else if (treeElement is Border)
            {
                TraverseVisualTree((treeElement as Border).Child, ref outList);
            }
            else
                ProcessVisualTreeElement(treeElement, ref outList);
        }

        private static void ProcessVisualTreeElement(object treeElement, ref List<object> outList)
        {
            if (treeElement is TextBox)
                outList.Add((treeElement as TextBox).Text);
            else if (treeElement is ComboBox)
                outList.Add((treeElement as ComboBox).SelectedItem);
        }
    }
}
