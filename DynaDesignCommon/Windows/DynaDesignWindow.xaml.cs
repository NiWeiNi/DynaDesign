using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Windows
{
    internal partial class DynaDesignWindow : Window
    {
        public DynaDesignWindow(Grid grid, double height, double width, string title)
        {
            // Load MaterialDesign libraries as they won't be properly handled by Revit otherwise
            // Code adopted from https://stackoverflow.com/questions/55594443/how-to-include-materialdesignxamltoolkit-to-wpf-class-library
            Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MaterialDesignThemes.Wpf.dll"));
            Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "MaterialDesignColors.dll"));
            // Load window style
            var materialDesignThemeWindow = new ResourceDictionary
            {
                Source = new Uri($"pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesign3.Window.xaml")
            };
            Resources.MergedDictionaries.Add(materialDesignThemeWindow);
            Style = (Style)FindResource("MaterialDesignWindow");
            string assemblyName = GetAssemblyName();
            string uri = $"/{assemblyName};component/Resources/Dictionaries/MaterialDesignLight.xaml";
            ResourceDictionary resourceDictionary = new ResourceDictionary();
            resourceDictionary.Source = new Uri(uri, UriKind.RelativeOrAbsolute);
            Resources.MergedDictionaries.Add(resourceDictionary);
            InitializeComponent();

            this.Content = grid;
            this.Height = height;
            this.Width = width;
            this.Title = title;
        }

        private string GetAssemblyName()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            return assembly.GetName().Name;
        }
    }
}