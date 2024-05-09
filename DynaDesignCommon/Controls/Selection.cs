using System.Collections.Generic;
using System.Windows.Controls;

namespace Controls
{
    public class Selection
    {
        private Selection() { }

        public static ComboBox CreateComboBox(List<object> list, string displayProp)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.ItemsSource = list;
            comboBox.DisplayMemberPath = displayProp;

            return comboBox;
        }
    }
}