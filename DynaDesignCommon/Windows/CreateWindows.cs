using System.Collections.Generic;
using System.Windows;
using WindowsCreation;


public class Windows
{
    private Windows() { }

    public static List<object> CreateWindows(object container, double height, double width, string title)
    {
        UIElement uIElement = container as UIElement;
        DynaDesignWindow window = new DynaDesignWindow(uIElement, height, width, title);
        window.ShowDialog();

        return window.outputSelection;
    }
}